using System;

namespace BattelshipKata.Domain.Extensions
{
    public static class PositionExtensions
    {
        public static bool IsEqualOrGrather(this Position point, Position target)
        {
            return point.X >= target.X && point.Y >= target.Y;
        }
        public static bool IsSmallerThan(this Position point, Position target)
        {
            return point.X < target.X && point.Y < target.Y;
        }
        public static Position Add(this Position position, Position target)
        {
            return new Position
            {
                X = position.X + target.X,
                Y = position.Y + target.Y
            };
        }
        public static Position Substract(this Position target, Position origin)
        {
            return new Position
            {
                X = target.X - origin.X,
                Y = target.Y - origin.Y
            };
        }
        public static Position Add(this Position position, int x, int y)
        {
            var nextPosition = new Position
            {
                X = x,
                Y = y
            };
            return position.Add(nextPosition);
        }
        public static Position Product(this Position position, int x)
        {
            var nextPosition = new Position
            {
                X = position.X * x,
                Y = position.Y * x
            };
            return nextPosition;
        }
         public static Position Division(this Position position, int x)
        {
            var nextPosition = new Position
            {
                X = position.X / x,
                Y = position.Y / x
            };
            return nextPosition;
        }
        public static int Distance(this Position target, Position origin)
        {
            return (int)Math.Sqrt(Math.Pow(target.X + origin.X, 2) + Math.Pow(target.Y + origin.Y, 2));
        }
        public static int ToBoardIndex(this Position position, int boardWidth)
        {
            return position.Y * boardWidth + position.X;
        }
    }

}