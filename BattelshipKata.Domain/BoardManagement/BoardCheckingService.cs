
using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.Extensions;

namespace BattelshipKata.Domain.BoardManagement
{
    public class BoardCheckingService
    {
        public SquareDiscoveringOutCome FireAway(IList<BoardSquare> squares, Position shotPosition, IEnumerable<Ship> ships, int boardWidth)
        {
            var result = CheckForHits(squares, shotPosition, boardWidth);
            if (result == SquareDiscoveringOutCome.Hit)
            {
                var hitShips = ships.Where(sh => sh.BoundingBox.RectangleContainsRuleFactory(shotPosition).IsMatch());
                if (hitShips.Any())
                {
                    var currShip = hitShips.First();
                    ships = ships.Select(sh =>
                    {
                        if (sh.BoundingBox.RectangleContainsRuleFactory(shotPosition).IsMatch())
                        {
                            sh.ShotsTaken = sh.ShotsTaken.Select(sht =>
                                {
                                    if(sht.Item1 == shotPosition)
                                    {
                                        sht.Item2 = true;
                                    }
                                    return sht;
                                }).ToList();
                        }
                        return sh;
                    });
                    if (currShip.ShipType == ShipType.Submarine)
                    {
                        return SquareDiscoveringOutCome.SunkedShip;
                    }
                    else
                    {
                        var isSunken = ships.Where(sh => sh.BoundingBox.RectangleContainsRuleFactory(shotPosition).IsMatch()).First().IsSunken;
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
        public SquareDiscoveringOutCome CheckForHits(IList<BoardSquare> squares, Position shotPosition, int boardWidth)
        {
            var index = shotPosition.ToBoardIndex(boardWidth);
            var currentSquare = squares[index];
            if (currentSquare.GameState == SquareGameState.Covered)
            {
                var outcome = currentSquare.Discover();
                return outcome;
            }
            return SquareDiscoveringOutCome.AlreadyHit;
        }
    }
}