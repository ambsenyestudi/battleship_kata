using System;
using System.Collections.Generic;
using BattelshipKata.Domain.BoardManagement;

namespace BattelshipKata.Test.BoardManagement.Fixtures
{
    public class BoardCheckingServiceFixture : IDisposable
    {
        public BoardCheckingService Sut { get; set; }
        public List<BoardSquare> Squares { get; set; }
        public BoardCheckingServiceFixture()
        {
            InitEmptyBoard();
            Sut = new BoardCheckingService();
        }

        public void InitEmptyBoard()
        {
            Squares = new List<BoardSquare>
            {
                new BoardSquare{GameState = SquareGameState.Covered }
            };
        }
        public void InitFullBoard()
        {
            Squares = new List<BoardSquare>
            {
                new BoardSquare
                {
                    GameState = SquareGameState.Covered,
                    IsFull = true 
                }
            };
        }

        public void Dispose()
        {
            Sut = null;
        }
    }
}