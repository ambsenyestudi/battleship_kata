using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.BoardRules
{
    public class SpacedShipsRule : IMatchRule
    {
        private readonly Board board;
        private readonly IEnumerable<Ship> ships;

        public SpacedShipsRule(Board board, IEnumerable<Ship> ships)
        {
            this.board = board;
            this.ships = ships;
        }
        public bool IsEqualOrSmaller(int min, int max, int eval)
        {
            return eval >= min && eval < max;
        }
        public IEnumerable<Ship> ShipsContainingPoint(IEnumerable<Ship> ships, Position point)
        {
            return ships.Where(sh => sh.BoundingBox.RectangleContainsRuleFactory(point).IsMatch());
        }
        public bool IsMatch()
        {
            var ShipPositionsMap = new List<bool>();
            var overlap = false;
            var isCorrectSpace = true;

            for (int y = 0; y < board.Size; y++)
            {
                for (int x = 0; x < board.Size; x++)
                {
                    var currPosition = new Position { X = x, Y = y };
                    var shipsContainingPoint = ShipsContainingPoint(ships, currPosition);
                    if (shipsContainingPoint.Count() > 1)
                    {
                        overlap = true;
                        break;
                    }
                    else
                    {
                        //refactor this in NoContiguous occupied squares on bord rule
                        var isOccupied = shipsContainingPoint.Count() > 0;
                        isCorrectSpace = !isOccupied || (x > 0 && ShipPositionsMap.Last()) != isOccupied;

                        if (!isCorrectSpace)
                        {
                            break;
                        }
                        if (isOccupied)
                        {
                            int nOccupied = CountSquaresOccupiedByNextShip(x, shipsContainingPoint);
                            for (int i = 0; i < nOccupied; i++)
                            {
                                ShipPositionsMap.Add(isOccupied);
                            }
                            x += nOccupied;
                        }
                        else
                        {
                            ShipPositionsMap.Add(isOccupied);
                        }

                    }
                }
            }

            return !overlap && isCorrectSpace;
        }

        private int CountSquaresOccupiedByNextShip(int x, IEnumerable<Ship> shipsContainingPoint)
        {
            var nextShip = shipsContainingPoint.First();
            var nOccupied = nextShip.BoundingBox.FigureEndPosition().X - x;
            return nOccupied;
        }
    }
}