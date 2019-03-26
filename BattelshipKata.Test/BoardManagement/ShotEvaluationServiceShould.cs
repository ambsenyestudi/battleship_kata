using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Test.BoardManagement.Fixtures;
using Moq;
using Xunit;

namespace BattelshipKata.Test.BoardManagement
{
    public class ShotEvaluationServiceShould : IClassFixture<ShotEvaluationServiceFixture>
    {
        private readonly ShotEvaluationServiceFixture fixture;

        public ShotEvaluationServiceShould(ShotEvaluationServiceFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        public void Create_evaluator()
        {
            
            var evaluator = fixture.DefaultShotEvaluatorFactory(Position.Zero);
            Assert.NotNull(evaluator);
        }
        [Fact]
        public void Not_succed_when_square_already_uncovered()
        {
            var updateMoq = fixture.BoardUpdateServiceFactory();
            var board = fixture.SingleSubAndRowBoardFactory(Position.Zero);
            //Uncover square
            board.BoardSquares[0].Discover(SquareDiscoveringOutCome.Miss);
            var evaluator = fixture.DefaultShotEvaluatorFactory(Position.Zero,board, updateMoq.Object);
            evaluator.EvaluateRulesChains();
            updateMoq.Verify(moq => moq.UpdateAlreadyHitOutcome(board), Times.Once());
            Assert.NotNull(evaluator);
        }
        [Fact]
        public void succed_when_ship_hit()
        {
            var updateMoq = fixture.BoardUpdateServiceFactory();
            var board = fixture.SingleSubAndRowBoardFactory(Position.Zero);
            var hitShotPos = Position.Zero;
            var evaluator = fixture.DefaultShotEvaluatorFactory(hitShotPos, board, updateMoq.Object);
            evaluator.EvaluateRulesChains();
            updateMoq.Verify(moq => moq.UpdateFleetAndBoardHits(board, hitShotPos), Times.Once());
            Assert.NotNull(evaluator);
        }

        [Fact]
        public void succed_when_ship_miss()
        {
            var updateMoq = fixture.BoardUpdateServiceFactory();
            var board = fixture.SingleSubBoardFactory(Position.Zero, 2, 2);
            var missShotPos = new Position{ X = 0, Y = 1};
            var evaluator = fixture.DefaultShotEvaluatorFactory(missShotPos, board, updateMoq.Object);
            evaluator.EvaluateRulesChains();
            updateMoq.Verify(moq => moq.UpdateMissShot(board, missShotPos), Times.Once());
            Assert.NotNull(evaluator);
        }
        [Fact]
        public void succed_when_sinking_ship()
        {
            // why do else rules not work?
            var updateMoq = fixture.BoardUpdateServiceFactory();
            var board = fixture.SingleSubAndRowBoardFactory(Position.Zero);
            HitAllPositionsOfFirstShip(board);
            var hitShotPos = Position.Zero;
            var evaluator = fixture.DefaultShotEvaluatorFactory(hitShotPos, board, updateMoq.Object);
            evaluator.EvaluateRulesChains();
            updateMoq.Verify(moq => moq.UpdateSunkOutcome(board), Times.Once());
            Assert.NotNull(evaluator);
        }

        private void HitAllPositionsOfFirstShip(Board board)
        {
            var max = board.Fleet[0].ShotsTaken.Count;
            for (int i = 0; i < max; i++)
            {
                var oldPos = board.Fleet[0].ShotsTaken[i].Item1;
                var newValue = (oldPos, true);
                board.Fleet[0].ShotsTaken[i] = newValue;
            }
        }
    }
}