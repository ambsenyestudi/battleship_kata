using System;
using System.Collections.Generic;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Ships;

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
        public void InitFullBoard(List<int> indexes, int width = 1, int height = 1)
        {
            InitEmptyBoard(width, height);
            foreach (var index in indexes)
            {
                Squares[index] = new BoardSquare
            {
                GameState = SquareGameState.Covered,
                IsFull = true
            };
            }
            
        }
        public Position InitSubmarineBoard(int size)
        {
            var subPose = new Position { X = 1, Y = 1 };
            int index = subPose.ToBoardIndex(size);
            
            InitFullBoard(new List<int>{index}, size, size);
            Ships.Clear();
            var sub = new Ship(ShipType.Submarine)
            {
                Position = subPose
            };
            Ships.Add(sub);
            return subPose;
        }
        public (Position, Position) InitBattleshipBoard(int size)
        {
            var battleshipPose = new Position { X = 1, Y = 0 };
            var battleshipEndPose = new Position { X = 1, Y = 3 };
            var indexes = new List<int>();
            var poses = GeneratePostionsFromToPoints(battleshipPose, battleshipEndPose, size);
            foreach (var pose in poses)
            {
                indexes.Add(pose.ToBoardIndex(size));
            }
            Ships.Clear();
            var battelship = new Ship(ShipType.Battelship)
            {
                Position = battleshipPose,
                ShipOrientation = ShipOrientation.Vertical
            };
            Ships.Add(battelship);
            InitFullBoard(indexes, size, size);


            return(battleshipPose, battleshipEndPose);
        }
        public List<Position> GeneratePostionsFromToPoints(Position start, Position end, int size)
        {
            var result = new List<Position>{start};
            var deltPost = end.Substract(start);
            var distance = end.Distance(start);
            for (int i = 0; i < distance; i++)
            {
                var incrementPose = deltPost.Division(distance);
                var nextPose = start.Add(incrementPose.Product(i+1));
                result.Add(nextPose);
            }
            return result;
        }

        public void Dispose()
        {
            Sut = null;
        }

        
    }
}