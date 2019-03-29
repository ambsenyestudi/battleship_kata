using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules.Base;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.BoardRules
{
    public class SpacedShipsRule : BaseRule
    {
        private readonly Board board;
        private readonly IEnumerable<Ship> ships;

        public SpacedShipsRule(Board board, IEnumerable<Ship> ships, Action actionToBeExecuted) : base(actionToBeExecuted)
        {
            this.board = board;
            this.ships = ships;
        }
        public List<IRule> CompareShips()
        {
            var rules = new List<IRule>();
            var alreadyPlacedShips = ships.Take(1).ToList();
            foreach (var ship in ships.Skip(1))
            {
                //scale 1
                var inBoardRule = new RectangleContainsRule(board.Bounds, ship.BoundingBox, null);
                if(inBoardRule.Eval().IsSuccess)
                {
                    var currShipRect = ship.BoundingBox.ScaleOne(board.Bounds.Position, new Position{ X = board.Bounds.MaxX, Y = board.Bounds.MaxY });
                    //Todo it must not intersecte any placed ship

                    //ship intersects las one
                    var shipIntersectsOthers = new RectangleContainsRule(currShipRect, alreadyPlacedShips.Last().BoundingBox, null); 
                    rules.Add(shipIntersectsOthers);
                }
                else
                {
                    //Add shipo failed to be in board
                    rules.Add(inBoardRule);
                }
                alreadyPlacedShips.Add(ship);
            }
            return rules;
        }

        public bool AreWellSpaced()
        {
            var result = false;
            if(ships!=null && ships.Any())
            {
                var rules = new List<IRule>();
                rules.Add(new RectangleContainsRule(board.Bounds, ships.First().BoundingBox, null));
                
                

                result = rules.Where(r=>!r.Eval().IsSuccess).Count() > 0;
            }
            return result;
        }

        public override IRuleResult Eval()
        {
            //todo eval rule

            return ruleResult;
        }
    }
}