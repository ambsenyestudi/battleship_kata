using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.MathRules;

namespace BattelshipKata.Domain.Extensions
{
    public static class RectangleExtensions
    {
        public static IMatchRule RectangleContainsRuleFactory(this Rectangle rect, Position point)
        {
            return new RectangleContainsRule(rect, point);
        }
        public static Position FigureEndPosition(this Rectangle rect)
        {
            return rect.Position.Add(rect.Width - 1, rect.Height - 1);
        }
        public static bool Contains(this Rectangle rect, Position point)
        {
            return rect.Position.X <= point.X && rect.MaxX >= point.X &&
                rect.Position.Y <= point.Y && rect.MaxY >= point.Y;
        }
    }
}