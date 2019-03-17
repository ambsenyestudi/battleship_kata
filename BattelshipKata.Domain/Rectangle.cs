using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.MathRules;

namespace BattelshipKata.Domain
{
    public class Rectangle
    {
        public Position Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public static Rectangle One
        {
            get => new Rectangle
            {
                Position = Position.Zero,
                Width = 1,
                Height = 1
            };
        }
    }
}