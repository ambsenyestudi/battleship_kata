using System.Collections.Generic;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Ships;
using BattelshipKata.Domain.Extensions;

namespace BattelshipKata.Test.Helpers
{
    public static class TestFactory
    {
        public static IList<Ship> GetSingleSumbarineAsShips(Position position = null)
        {
            if (position == null)
            {
                position = Position.Zero;
            }
            var sub = new Submarine();
            sub.Position = position;
            return new List<Ship> { sub };
        }
        public static IList<BoardSquare> GetSquares(int nSquares)
        {

            var square = new List<BoardSquare>();
            for (int i = 0; i < nSquares; i++)
            {
                square.Add(new BoardSquare());
            }
            return square;
        }
        public static IList<Position> GetPositionsFromIndexFactory(int maxIndex, int boardWidth)
        {
            var indexes = new List<int>();
            for (int i = 0; i < maxIndex; i++)
            {
                indexes.Add(i);
            }
            return GetPositionsFromIndexFactory(indexes, boardWidth);
        }
        public static IList<Position> GetPositionsFromIndexFactory(IEnumerable<int> indexes, int boardWidth)
        {
            var positions = new List<Position>();
            foreach (var index in indexes)
            {
                var pos = index.ToPositionFromBoardIndex(boardWidth);
                positions.Add(pos);
            }
            return positions;
        }
    }
}