using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.MathRules;

namespace BattelshipKata.Domain.Extensions
{
    public static class RectangleExtensions
    {
        public static Position FigureEndPosition(this Rectangle rect)
        {
            return rect.Position.Add(rect.Width - 1, rect.Height - 1);
        }
        public static bool Contains(this Rectangle rect, Position point)
        {
            return rect.Position.X <= point.X && rect.MaxX >= point.X &&
                rect.Position.Y <= point.Y && rect.MaxY >= point.Y;
        }
        //this is not too clear
        public static Rectangle ScaleOne(this Rectangle rect, Position minPosition = null, Position maxPosition = null)
        {
            var nextPos = rect.Position;
            var minExists = minPosition != null;
            var maxExists = maxPosition != null;
            var nextWidth = rect.Width;
            var nextHeight = rect.Height;
            if( !minExists || (minExists && nextPos > minPosition))
            {
                nextPos = rect.Position - Position.One;
                nextWidth++;
                nextHeight++;
            }
            if(!maxExists || (maxExists && new Position{ X = rect.MaxX, Y = rect.MaxY} < maxPosition))
            {
                nextWidth++;
                nextHeight++;
            }
            return new Rectangle{
                Position = nextPos,
                Width = nextWidth,
                Height = nextHeight
            };
        }
    }
}