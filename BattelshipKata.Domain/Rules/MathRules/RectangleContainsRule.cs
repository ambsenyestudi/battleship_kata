using System;
using BattelshipKata.Domain.Rules.Base;

namespace BattelshipKata.Domain.Rules
{
    public class RectangleContainsRule : BaseRule
    {
        private readonly Rectangle bigRect;
        private readonly Rectangle smallRect;

        public RectangleContainsRule(Rectangle bigRect, Rectangle smallRect,Action actionToBeExecuted) : base(actionToBeExecuted)
        {
            this.bigRect = bigRect;
            this.smallRect = smallRect;
        }

        public override IRuleResult Eval()
        {
            ruleResult.IsSuccess = bigRect.Position.X <= smallRect.Position.X && bigRect.MaxX >= smallRect.MaxX &&
                bigRect.Position.Y <= smallRect.Position.Y && bigRect.MaxY >= smallRect.MaxY;
            return ruleResult;
        }
    }
}