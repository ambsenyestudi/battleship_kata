using System.Collections.Generic;
using System.Linq;

namespace BattelshipKata.Domain.Rules.BoardRules
{
    public class SpacedShipsRule : IRule
    {
        private readonly Board board;
        private readonly IOrderedEnumerable<Ship> ships;

        public SpacedShipsRule(Board board, IEnumerable<Ship> ships)
        {
            this.board = board;
            this.ships = ships.OrderBy(s => s.Position.Item2).ThenBy(s => s.Position.Item1);
        }
        public bool IsEqualOrSmaller(int min, int max, int eval)
        {
            return eval >= min && eval < max;
        }
        public bool IsShipMatch(int x, int y, Ship ship)
        {
            var result = false;
            if(ship.ShipOrientation == ShipOrientation.Horizontal)
            {
                result = ship.Position.Item2 == y;
                if(result)
                {
                    var min = ship.Position.Item1;
                    var max = min + ship.Size;
                    result = IsEqualOrSmaller(min, max, x);
                }
            }
            else
            {
                result = ship.Position.Item1 == x;
                if(result)
                {
                    var min = ship.Position.Item2;
                    var max = min + ship.Size;
                    result = IsEqualOrSmaller(min, max, y);
                }
            }
            return result;
        }
        public int ShipMatchCount(int x, int y, IEnumerable<Ship> ships)
        {
            return ships.Where(s => IsShipMatch(x, y, s)).Count();
        }
        public bool IsMatch()
        {
            var Position = new List<bool>();
            var overlap = false;

            for (int y = 0; y < board.Size; y++)
            {
                for (int x = 0; x < board.Size; x++)
                {
                    var shipMatchCount = ShipMatchCount(x, y, ships);
                    if (shipMatchCount > 1)
                    {
                        overlap = true;
                        break;
                    }
                    else
                    {
                        Position.Add(shipMatchCount == 1);
                    }
                }
            }

            return !overlap;
        }
    }
}