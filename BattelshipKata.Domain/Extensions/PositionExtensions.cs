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
        public static Position Add(this Position position, int x, int y)
        {
            var nextPosition = new Position
            {
                X = x,
                Y = y
            };
            return position.Add(nextPosition);
        }
    }

}