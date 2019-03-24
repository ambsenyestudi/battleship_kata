using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Rules.ShotRules;
using BattelshipKata.Domain.Ships;
using BattelshipKata.Test.Helpers;
using Moq;

namespace BattelshipKata.Test.Rules.ShotRules
{
    public class HitShotFixture : IDisposable
    {
        public Mock<IBoardUpdateService> BoardUpdateServiceMock { get; set; }
        public HitShotFixture()
        {
            InitBardUpdateMock();
        }
        public void InitBardUpdateMock()
        {
            BoardUpdateServiceMock = new Mock<IBoardUpdateService>();
            BoardUpdateServiceMock.Setup(moq => moq.UpdateFleetAndBoardHits(It.IsAny<Board>(), It.IsAny<Position>()));
        }
        public Board SingleSubmarineBoardFactory(Position subPos, int width = 1, int height = 1)
        {
            var ships = TestFactory.GetSingleSumbarineAsShips(subPos);
            return BoardFactory(ships, width, height);
        }
        public Board BoardFactory(IList<Ship> ships, int width, int height) => 
           BoardFactory(TestFactory.GetSquares(width * height).ToList(), ships, width);
        public Board BoardFactory(List<BoardSquare> squares, IList<Ship> ships, int size) => 
            new Board{BoardSquares = squares, Fleet=ships, Size = size};
        public ShotHitRule ShotHitRuleFactory(Board board, Position position)
        {
            return new ShotHitRule(board, position,
                ()=>{
                    BoardUpdateServiceMock.Object.UpdateFleetAndBoardHits(board, position);
                });
            
        }
        public void Dispose()
        {
            BoardUpdateServiceMock = null;
        }
    }
}