using System;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules.Base;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.ShipRules
{
    public class HitRule : BaseRule
    {
        private readonly Ship ship;
        private readonly Position shotPosition;

        public HitRule(Ship ship, Position pos, Action actionToBeExecuted) : base(actionToBeExecuted)
        {
            this.ship = ship;
            this.shotPosition = pos;
        }

        public override IRuleResult Eval()
        {
            ruleResult.IsSuccess = ship.BoundingBox.Contains(shotPosition);
            return ruleResult;
        }
    }
}