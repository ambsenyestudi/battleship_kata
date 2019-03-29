
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
            else
            {
                var isFirst = bigRect.Position.X <= smallRect.Position.X && bigRect.MaxX >= smallRect.Position.X && 
                    smallRect.Position.Y <= bigRect.Position.Y && smallRect.MaxY >= bigRect.Position.Y;

                var isSecond = bigRect.Position.Y <= smallRect.Position.Y && bigRect.MaxY >= smallRect.Position.Y &&
                    smallRect.Position.X <= bigRect.Position.X && smallRect.MaxX >= bigRect.Position.X;

                isIntersect = isFirst || isSecond;
            }
            ruleResult.IsSuccess = isIntersect;
            return ruleResult;
        }
    }
}