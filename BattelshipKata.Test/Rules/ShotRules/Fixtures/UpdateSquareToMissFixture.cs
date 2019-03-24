using System;
using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Test.Helpers;
using Moq;

namespace BattelshipKata.Test.Rules.ShotRules
{
    public class UpdateSquareToMissFixture : IDisposable
    {
        public Mock<IBoardUpdateService> BoardUpdateServiceMock { get; set; }
        public UpdateSquareToMissFixture()
        {
            InitBardUpdateMock();
        }
        public void InitBardUpdateMock()
        {
            BoardUpdateServiceMock = new Mock<IBoardUpdateService>();
            BoardUpdateServiceMock.Setup(moq => moq.UpdateMissShot(It.IsAny<Board>(), It.IsAny<Position>()));
        }
        public Board Init2x2SubAtBottom()
        {
            var width = 2;
            var height = 2;
            var squares = TestFactory.GetSquares(width * height);
            var subPos = new Position { X = 0, Y = 1 };
            
            var ships = TestFactory.GetSingleSumbarineAsShips(subPos);
            return new Board{BoardSquares = squares.ToList(), Fleet = ships, Size = width};
        }
        public void Dispose()
        {
            BoardUpdateServiceMock = null;
        }
    }
}