using BattelshipKata.Domain;
using BattelshipKata.Domain.Extensions;
using Xunit;

namespace BattelshipKata.Test
{
    public class RectangleScalerShould
    {
        [Fact]
        public void Substract_position()
        {
            //Given
            var expected = Position.Zero;
            var rect = Rectangle.One;
            rect.Position = Position.One;

            //When
            var resultRect = rect.ScaleOne();

            //Then
            Assert.True(expected == resultRect.Position);
        }
        [Fact]
        public void Substract_position_when_greater_than_min()
        {
            //Given
            var expected = Position.Zero;
            var rect = Rectangle.One;
            rect.Position = Position.One;

            //When
            var resultRect = rect.ScaleOne(Position.Zero);

            //Then
            Assert.True(expected == resultRect.Position);
        }
        [Fact]
        public void Substract_add_maxXY()
        {
            //Given
            var expected = 2;
            var rect = Rectangle.One;
            rect.Position = Position.One;

            //When
            var resultRect = rect.ScaleOne();

            //Then
            Assert.True(expected == resultRect.MaxX && expected == resultRect.MaxY);
        }
        [Fact]
        public void Not_grow_further_than_min_position()
        {
            //Given
            var expected = Position.Zero;
            var rect = Rectangle.One;

            //When
            var resultRect = rect.ScaleOne(Position.Zero);

            //Then
            Assert.True(expected == resultRect.Position);
        }
        [Fact]
        public void Not_grow_further_than_One()
        {
            //Given
            var expected = 0;
            var rect = Rectangle.One;

            //When
            var resultRect = rect.ScaleOne(Position.Zero, Position.Zero);

            //Then
            Assert.True(expected == resultRect.MaxX && expected == resultRect.MaxY);
        }
        [Fact]
        public void Not_grow_further_than_max_position()
        {
            //Given
            var expected = 1;
            var rect = Rectangle.One;
            rect.Position = Position.One;

            //When
            var resultRect = rect.ScaleOne(Position.Zero, new Position { X = 1, Y = 1 });

            //Then
            Assert.True(expected == resultRect.MaxX && expected == resultRect.MaxY);
        }
         [Fact]
        public void Not_grow_when_in_min_and_max()
        {
            //Given
            var expected = 2;
            var rect = Rectangle.One;
            rect.Position = Position.One;

            //When
            var resultRect = rect.ScaleOne(Position.Zero, new Position { X = 3, Y = 3 });

            //Then
            Assert.True(expected == resultRect.MaxX && expected == resultRect.MaxY);
        }
    }
}