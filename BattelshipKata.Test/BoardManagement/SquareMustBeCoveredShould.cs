using System.Collections.Generic;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Rules.BoardRules;
using Xunit;

namespace BattelshipKata.Test.BoardManagement
{
    public class SquareMustBeCoveredShould
    {
        [Fact]
        public void Discover_when_square_covered()
        {
            //Given
            var squares = new List<BoardSquare>{
                BoardSquareFactory()
            };
            var sut = new SquareMustBeCoveredRule(squares, Position.Zero, 1, null);
            //When
            var result = sut.Eval();
            //Then
            Assert.True(result.IsSuccess);
        }
        [Fact]
        public void Not_discover_when_square_missed()
        {
            //Given
            var squares = new List<BoardSquare>{
                BoardSquareFactory(SquareDiscoveringOutCome.Miss)
            };
            var sut = new SquareMustBeCoveredRule(squares, Position.Zero, 1, null);
            //When
            var result = sut.Eval();
            //Then
            Assert.False(result.IsSuccess);
        }
        [Fact]
        public void Not_discover_when_square_hit()
        {
            //Given
            var squares = new List<BoardSquare>{
                BoardSquareFactory(SquareDiscoveringOutCome.Hit)
            };
            var sut = new SquareMustBeCoveredRule(squares, Position.Zero, 1, null);
            //When
            var result = sut.Eval();
            //Then
            Assert.False(result.IsSuccess);
        }

        private static BoardSquare BoardSquareFactory(SquareDiscoveringOutCome gameState = SquareDiscoveringOutCome.AlreadyHit)
        {
            var board = new BoardSquare();
            board.Discover(gameState);
            return board;
        }
    }
}