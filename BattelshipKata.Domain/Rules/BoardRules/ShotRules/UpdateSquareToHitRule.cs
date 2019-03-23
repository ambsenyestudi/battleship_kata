
using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules.Base;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.BoardRules.ShotRules
{
    public class UpdateSquareToHitRule : BaseRule
    {
        private IList<BoardSquare> squares;
        private IEnumerable<Ship> ships;
        private Position shotPosition;

        public UpdateSquareToHitRule(IList<BoardSquare> squares,
            IEnumerable<Ship> ships,
            Position shotPosition, int boardWith) : base(() =>
            {
                DiscoverPosition(squares,ships, shotPosition, boardWith);
            })
        {
            this.squares = squares;
            this.ships = ships;
            this.shotPosition = shotPosition;
        }
        public override IRuleResult Eval()
        {
            //this should be moved to the action at base
            var hitShips = GetFirstHitRule(ships, shotPosition);
            if (hitShips != null)
            {
                return this.ruleResult;
            }
            return new RuleResult();
        }
        public static IMatchRule GetFirstHitRule(IEnumerable<Ship> ships,
            Position shotPosition)
        {
            var hitShips = ships.Where(sh =>sh.HitRuleFactory(shotPosition).IsMatch())
                .Select(sh =>sh.HitRuleFactory(shotPosition));
            if(hitShips.Any())
            {
                return hitShips.First();
            }
            return null;
        }
        public static void DiscoverPosition(IList<BoardSquare> squares,
            IEnumerable<Ship> ships,
            Position shotPosition, int boardWidth)
        {
            var hitMatchRule = GetFirstHitRule(ships, shotPosition);
            if(hitMatchRule != null)
            {
                var index = shotPosition.ToBoardIndex(boardWidth);
                squares[index].Discover(hitMatchRule);
            }
        }
    }
}