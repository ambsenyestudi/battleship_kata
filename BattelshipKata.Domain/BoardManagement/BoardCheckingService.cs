
using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.BoardManagement
{
    public class BoardCheckingService
    {
        //make ships check then complete board with misses and ships and board with hits
        public IEnumerable<Ship> CheckShipsHit(Position shotPosition, IEnumerable<Ship> ships)
        {
            var hitShips = ships.Where(sh => sh.BoundingBox.RectangleContainsRuleFactory(shotPosition).IsMatch());
            return hitShips;
        }
        public SquareDiscoveringOutCome FireAway(IList<BoardSquare> squares, Position shotPosition, IEnumerable<Ship> ships, int boardWidth)
        {
            var hitShips = CheckShipsHit(shotPosition, ships);
            if (hitShips.Any())
            {
                var currShip = hitShips.First();
                var wasSunken = currShip.IsSunken;
                currShip.UpdateShotsTaken(shotPosition);
                if(currShip.IsSunken)
                {
                    return SquareDiscoveringOutCome.SunkedShip;
                }
                else
                {
                    return SquareDiscoveringOutCome.Hit;
                }
            }
            else
            {
                var index = shotPosition.ToBoardIndex(boardWidth);
                if (squares[index].GameState == SquareGameState.Covered)
                {
                    return SquareDiscoveringOutCome.Miss;
                }
                else
                {
                    return SquareDiscoveringOutCome.AlreadyHit;
                }
            }
        }

    }
}