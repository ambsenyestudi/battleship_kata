
using BattelshipKata.Domain;
using Xunit;

namespace BattelshipKata.Test.Rules.ShotRules
{
    public class RectangleIntersectsShould : IClassFixture<RectangleIntersectsFixture>
    {
        private readonly RectangleIntersectsFixture fixture;

        public RectangleIntersectsShould(RectangleIntersectsFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        public void Fail_when_independent_rects()
        {
            //Given
            var expected = false;
            var rectOne = Rectangle.One;
            var rectTwo = Rectangle.One;
            rectTwo.Position = Position.One;
            var rule = fixture.RuleFactory(rectOne, rectTwo);
            //When
            var result = rule.Eval().IsSuccess;
            //Then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Succed_when_same_rects()
        {
            //Given
            var expected = true;
            var rectOne = Rectangle.One;
            var rule = fixture.RuleFactory(rectOne, rectOne);
            //When
            var result = rule.Eval().IsSuccess;
            //Then
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Succed_when_second_overlaps_first_horizontally()
        {
            //Given
            var expected = true;
            var rectOne =  new Rectangle()
            {
                Width = 2,
                Height = 1,
                Position = Position.Zero
            };
            var rectTwo = new Rectangle()
            {
                Width = 3,
                Height = 1,
                Position = new Position { X = 1, Y = 0 }
            };
            var rule = fixture.RuleFactory(rectOne, rectTwo);
            //When
            var result = rule.Eval().IsSuccess;
            //Then
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Succed_when_second_overlaps_first_vertically()
        {
            //Given
            var expected = true;
            var rectOne =  new Rectangle()
            {
                Width = 1,
                Height = 2,
                Position = new Position { X = 2, Y = 0 }
            };
            var rectTwo = new Rectangle()
            {
                Width = 3,
                Height = 1,
                Position = new Position { X = 0, Y = 0 }
            };
            var rule = fixture.RuleFactory(rectOne, rectTwo);
            //When
            var result = rule.Eval().IsSuccess;
            //Then
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Succed_when_first_overlaps_second_horizontally()
        {
            //Given
            var expected = true;
            var rectOne = new Rectangle()
            {
                Width = 3,
                Height = 1,
                Position = new Position { X = 1, Y = 0 }
            };
            var rectTwo = new Rectangle()
            {
                Width = 2,
                Height = 1,
                Position = Position.Zero
            };
            var rule = fixture.RuleFactory(rectOne, rectTwo);
            //When
            var result = rule.Eval().IsSuccess;
            //Then
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Succed_when_first_overlaps_second_vertically()
        {
            //Given
            var expected = true;
            var rectOne =  new Rectangle()
            {
                Width = 3,
                Height = 1,
                Position = new Position { X = 0, Y = 1 }
            };
            var rectTwo = new Rectangle()
            {
                Width = 1,
                Height = 2,
                Position = Position.Zero
            };
            var rule = fixture.RuleFactory(rectOne, rectTwo);
            //When
            var result = rule.Eval().IsSuccess;
            //Then
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Fail_when_rects_do_not_overlap_vertically()
        {
            //Given
            var expected = false;
            var rectOne =  new Rectangle()
            {
                Width = 2,
                Height = 1,
                Position = Position.Zero
            };
            var rectTwo = new Rectangle()
            {
                Width = 3,
                Height = 1,
                Position = new Position { X = 0, Y = 1 }
            };
            var rule = fixture.RuleFactory(rectOne, rectTwo);
            
            //When
            var result = rule.Eval().IsSuccess;
            //Then
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Succed_rects_no_overlap_vertically()
        {
            //Given
            var expected = false;
            var rectOne =  new Rectangle()
            {
                Width = 2,
                Height = 1,
                Position = Position.Zero
            };
            var rectTwo = new Rectangle()
            {
                Width = 3,
                Height = 1,
                Position = new Position { X = 0, Y = 1 }
            };
            var rule = fixture.RuleFactory(rectOne, rectTwo);
            
            //When
            var result = rule.Eval().IsSuccess;
            //Then
            Assert.Equal(expected, result);
        }
    }
}