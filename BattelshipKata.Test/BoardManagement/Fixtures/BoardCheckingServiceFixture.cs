using System;
using System.Collections.Generic;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;

namespace BattelshipKata.Test.BoardManagement.Fixtures
{
    public class BoardCheckingServiceFixture : IDisposable
    {
        public BoardCheckingService Sut { get; set; }
        public List<BoardSquare> Squares { get; set; }
        public List<Ship> Ships { get; set; }
        public BoardCheckingServiceFixture()
        {
            InitEmptyBoard();
            Ships = new List<Ship>();
            Sut = new BoardCheckingService();
        }

        public void InitEmptyBoard(int width = 1, int height = 1)
        {
            var squares = new List<BoardSquare>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var nextSquare = new BoardSquare { GameState = SquareGameState.Covered };
                    squares.Add(nextSquare);
                }
            }
            Squares = squares;

        }
        public void InitFullBoard()
        {
            InitEmptyBoard();
            Squares[0] = new BoardSquare
            {
                GameState = SquareGameState.Covered,
                IsFull = true
            };
        }
        public Position InitSubmarineBoard()
        {
            int size = 3;
            int index = 4;
            var subPose = new Position { X = index / size, Y = index % size };
            InitEmptyBoard(size, size);
            Squares[index] = new BoardSquare
            {
                GameState = SquareGameState.Covered,
                IsFull = true
            };
            Ships.Clear();
            var sub = new Ship(ShipType.Submarine)
            {
                Position = subPose
            };
            Ships.Add(sub);
            return subPose;
        }

        public void Dispose()
        {
            Sut = null;
        }
    }
}