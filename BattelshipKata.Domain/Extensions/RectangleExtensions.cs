using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.MathRules;

namespace BattelshipKata.Domain.Extensions
{
    public static class RectangleExtensions
    {
        public static IRule RectangleContainsRuleFactory(this Rectangle rect, Position point)
        {
            return new RectangleContainsRule(rect, point);
        }
        public static Position FigureEndPosition(this Rectangle rect)
        {
            return rect.Position.Add(rect.Width -1, rect.Height -1);
        }
    }
}