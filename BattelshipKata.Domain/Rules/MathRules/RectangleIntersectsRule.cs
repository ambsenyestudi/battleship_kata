
using System;
using BattelshipKata.Domain.Rules.Base;
using BattelshipKata.Domain.Extensions;

namespace BattelshipKata.Domain.Rules.MathRules
{
    public class RectangleIntersectsRule : BaseRule
    {
        private readonly Rectangle bigRect;
        private readonly Rectangle smallRect;

        public RectangleIntersectsRule(Rectangle bigRect, Rectangle smallRect, Action actionToBeExecuted) : base(actionToBeExecuted)
        {
            this.bigRect = bigRect;
            this.smallRect = smallRect;
        }

        public override IRuleResult Eval()
        {
            var isIntersect = false;
            if(bigRect.Position == smallRect.Position)
            {
                isIntersect = true;
            }
            else if(bigRect.Contains(smallRect.Position) || smallRect.Contains(bigRect.Position))
            {
                isIntersect = true;
            }
            ruleResult.IsSuccess = isIntersect;
            return ruleResult;
        }
    }
}