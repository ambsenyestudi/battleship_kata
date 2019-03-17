using BattelshipKata.Domain;
using BattelshipKata.Domain.Extensions;

namespace BattelshipKata.Domain.Rules.MathRules
{
    public class RectangleContainsRule : IRule
    {
        private readonly Rectangle rectangle;
        private readonly Position point;

        public RectangleContainsRule(Rectangle rect, Position point)
        {
            this.rectangle = rect;
            this.point = point;
        }
        public bool IsMatch()
        {
            return point.IsEqualOrGrather(rectangle.Position)
                && point.IsSmallerThan(
                    rectangle.Position.Add(rectangle.Width, rectangle.Height));
        }
    }
}
