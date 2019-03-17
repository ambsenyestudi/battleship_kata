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
    }
}