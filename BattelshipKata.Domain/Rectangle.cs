using System.Collections.Generic;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.MathRules;

namespace BattelshipKata.Domain
{
    public class Rectangle
    {
        public Position Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MaxX { get => Position.X + (Width - 1); }
        public int MaxY { get => Position.Y + (Height - 1); }

        public static Rectangle One
        {
            get => new Rectangle
            {
                Position = Position.Zero,
                Width = 1,
                Height = 1
            };
        }
        public List<Position> GetAllRectanglePositions()
        {
            var result = new List<Position>();
            if (Width > 1)
            {
                for (int x = 0; x < Width; x++)
                {
                    result.Add(Position.Add(new Position { X = x, Y = 0 }));
                }
            }
            if (Height > 1)
            {
                for (int y = 0; y < Height; y++)
                {
                    result.Add(Position.Add(new Position { X = 0, Y = y }));
                }
            }
            return result;
        }
    }
}