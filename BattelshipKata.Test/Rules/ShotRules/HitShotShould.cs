using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Rules.ShotRules;
using BattelshipKata.Test.Helpers;
using Moq;
using Xunit;

namespace BattelshipKata.Test.Rules.ShotRules
{
    public class HitShotShould : IClassFixture<HitShotFixture>
    {
        private readonly HitShotFixture fixture;

        public HitShotShould(HitShotFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        public void Hit_successfully_on_occupied_square()
        {
            fixture.InitBardUpdateMock();
            //Given 2 x 1 Board
            var size = 2;
            var hitPos = Position.Zero;
            var board = fixture.SingleSubmarineBoardFactory(hitPos, size);
            var rule = fixture.ShotHitRuleFactory(board, hitPos);
            //When
            var evaluator = rule.Eval();
            if (evaluator.IsSuccess)
            {
                evaluator.Execute();
            }
            //Then
            fixture.BoardUpdateServiceMock.Verify(moq => moq.UpdateFleetAndBoardHits(It.IsAny<Board>(), It.IsAny<Position>()), Times.Once);
            Assert.True(evaluator.IsSuccess);
        }
        
        [Fact]
        public void Not_hit_successfully_on_occupied_square()
        {
            fixture.InitBardUpdateMock();
            //Given 2 x 2 Board
            var width = 2;
            var height = 2;
            var subPos = new Position { X = 0, Y = 1 };
            var missPos = Position.Zero;
            var board = fixture.SingleSubmarineBoardFactory(subPos, width, height);
            var rule = fixture.ShotHitRuleFactory(board, missPos);
            //When
            var IsSuccess = rule.Eval().IsSuccess;
            //Then
            fixture.BoardUpdateServiceMock.Verify(moq => moq.UpdateFleetAndBoardHits(It.IsAny<Board>(), It.IsAny<Position>()), Times.Never);
            Assert.False(IsSuccess);
        }
        
        [Fact]
        public void Not_discover_on_square_hit_rule_fail()
        {
            fixture.InitBardUpdateMock();
            //Given 2 x 2 Board
            var width = 2;
            var height = 2;
            var subPos = new Position { X = 0, Y = 1 };
            var missPos = Position.Zero;
            var ships = TestFactory.GetSingleSumbarineAsShips(subPos);
            var board = fixture.SingleSubmarineBoardFactory(subPos, width, height);
            var rule = fixture.ShotHitRuleFactory(board, missPos);
            //When
            var evaluator = rule.Eval();
            var IsSuccess = evaluator.IsSuccess;
            //this is wrong on purpuse to test extreme case
            evaluator.Execute();
            //Then
            fixture.BoardUpdateServiceMock.Verify(moq => moq.UpdateFleetAndBoardHits(It.IsAny<Board>(), It.IsAny<Position>()), Times.Never);
            Assert.False(IsSuccess);
        }
    }

}