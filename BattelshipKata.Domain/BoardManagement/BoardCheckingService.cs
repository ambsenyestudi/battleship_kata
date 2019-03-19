
using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.Extensions;

namespace BattelshipKata.Domain.BoardManagement
{
    public class BoardCheckingService
    {
        public SquareDiscoveringOutCome FireAway(IEnumerable<BoardSquare> squares,Position shotPosition, IEnumerable<Ship> ships)
        {
            var result = CheckForHits(squares, shotPosition);
            if(result == SquareDiscoveringOutCome.Hit)
            {
                var hitShips = ships.Where(sh =>sh.BoundingBox.RectangleContainsRuleFactory(shotPosition).IsMatch());
                if(hitShips.Any())
                {
                    var currShip = hitShips.First();
                    if(currShip.ShipType == ShipType.Submarine)
                    {
                        return SquareDiscoveringOutCome.SunkedShip;
                    }
                }
                else
                {
                    //Something when wrong when mapping ships
                }
            }
            return result;
        }
        public SquareDiscoveringOutCome CheckForHits(IEnumerable<BoardSquare> squares,Position shotPosition)
        {
            var currentSquare = squares.First(); 
            if(currentSquare.GameState == SquareGameState.Covered)
            {
                var outcome = currentSquare.Discover();
                return outcome;
            }
            return SquareDiscoveringOutCome.AlreadyHit;
        }
    }
}