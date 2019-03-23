using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.ShipRules
{
    public class HitRule : IMatchRule
    {
        private readonly Ship ship;
        private readonly Position shotPosition;
        private readonly IMatchRule shotInBoundingBoxRule;

        public HitRule(Ship ship, Position shotPosition)
        {
            this.shotInBoundingBoxRule = ship.BoundingBox.RectangleContainsRuleFactory(shotPosition);
        }
        public bool IsMatch()
        {
            return shotInBoundingBoxRule.IsMatch();
        }
    }
}