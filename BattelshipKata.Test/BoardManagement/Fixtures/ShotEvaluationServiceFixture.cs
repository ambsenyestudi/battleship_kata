
using System;
using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Test.Helpers;
using Moq;

namespace BattelshipKata.Test.BoardManagement.Fixtures
{
    public class ShotEvaluationServiceFixture : IDisposable
    {
        public Mock<IBoardUpdateService> BoardUpdateServiceFactory()
        {
            var sutMoq = new Mock<IBoardUpdateService>();
            sutMoq.Setup(moq =>moq.ResetOutcome(It.IsAny<Board>()));
            sutMoq.Setup(moq =>moq.UpdateAlreadyHitOutcome(It.IsAny<Board>()));
            sutMoq.Setup(moq =>moq.UpdateFleetAndBoardHits(It.IsAny<Board>(), It.IsAny<Position>()))
                .Callback((Board b, Position p) => {
                    //logic a little biased
                    b.LastActionOutcome = new ShotActionOutcome
                    {
                        Outcome = SquareDiscoveringOutCome.Hit,
                        Ship = b.Fleet.First()
                    };
                });
            sutMoq.Setup(moq =>moq.UpdateMissShot(It.IsAny<Board>(), It.IsAny<Position>()));
            sutMoq.Setup(moq =>moq.UpdateSunkOutcome(It.IsAny<Board>()));
            return sutMoq;
        }
        public Board SingleSubAndRowBoardFactory(Position subPos)
        {
            var width = 2;
            var height = 1;
            return SingleSubBoardFactory(subPos, width, height);
        }
        public Board SingleSubBoardFactory(Position subPos, int width, int height)
        {
            return new Board
            {
                BoardSquares = TestFactory.GetSquares(width * height).ToList(),
                Size = width,
                Fleet = TestFactory.GetSingleSumbarineAsShips(subPos)
            };
        }
        public RulesEvaluator DefaultShotEvaluatorFactory(Position shotPosition, Board board = null, IBoardUpdateService updateService = null)
        {
            if(updateService == null)
            {
                updateService = BoardUpdateServiceFactory().Object;
            }
            var sut = new ShotEvaluationService(updateService);
            var pos = Position.Zero;
            if (board == null)
            {
                board = SingleSubAndRowBoardFactory(pos);
            }
            //When
            var evaluator = sut.BuildShotRulesEvaluator(board, shotPosition);
            return evaluator;
        }
        public void Dispose()
        {
            //ToDo
        }
    }
}