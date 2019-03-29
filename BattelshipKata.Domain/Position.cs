namespace BattelshipKata.Domain
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static Position Zero
        {
            get => new Position
            {
                X = 0,
                Y = 0
            };
        }
        public static Position One
        {
            get => new Position
            {
                X = 1,
                Y = 1
            };
        }
        public static bool operator ==(Position a, Position b)
        {
            if (object.ReferenceEquals(null, a))
            {
                return object.ReferenceEquals(null, b);
            }
            else if (object.ReferenceEquals(null, b))
            {
                return false;
            }
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(Position a, Position b)
        {
            if (object.ReferenceEquals(null, a))
            {
                return !object.ReferenceEquals(null, b);
            }
            else if (object.ReferenceEquals(null, b))
            {
                return true;
            }
            return a.X != b.X || a.Y != b.Y;
        }
        public static bool operator >(Position a, Position b)
        {
            if(a==null || b==null)
            {
                return false;
            }
            return a.X > b.X || a.Y > b.Y;
        }
        public static bool operator <(Position a, Position b)
        {
            if(a==null || b==null)
            {
                return false;
            }
            return a.X < b.X || a.Y < b.Y;
        }
        public static Position operator -(Position a, Position b)
        {
            return new Position
            {
                X = a.X - b.X,
                Y = a.Y - b.Y
            };
        }
    }
}