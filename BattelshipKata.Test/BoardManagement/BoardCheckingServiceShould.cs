using System.Collections.Generic;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Test.BoardManagement.Fixtures;
using Xunit;

namespace BattelshipKata.Test.BoardManagement
{
    public class BoardCheckingServiceShould:IClassFixture<BoardCheckingServiceFixture>
    {
        private readonly BoardCheckingServiceFixture fixture;

        public BoardCheckingServiceShould(BoardCheckingServiceFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        public void Tell_you_when_position_already_tried()
        {   
            fixture.InitEmptyBoard();
            var expected = SquareDiscoveringOutCome.AlreadyHit;
            fixture.Sut.CheckForHits(fixture.Squares, Position.Zero);
            var result = fixture.Sut.CheckForHits(fixture.Squares, Position.Zero);


            Assert.Equal(expected, result);
        }
        [Fact]
        public void Miss_when_empty_square()
        {
            fixture.InitEmptyBoard();
            var expected = SquareDiscoveringOutCome.Miss;
            var result = fixture.Sut.CheckForHits(fixture.Squares, Position.Zero);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Hit_when_full_square()
        {
            fixture.InitFullBoard();
            var expected = SquareDiscoveringOutCome.Hit;
            var result = fixture.Sut.CheckForHits(fixture.Squares, Position.Zero);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Sunk_when_submarine_hit()
        {
            var subPose = fixture.InitSubmarineBoard();
            fixture.InitFullBoard();
            var expected = SquareDiscoveringOutCome.SunkedShip;
            var result = fixture.Sut.FireAway(fixture.Squares, subPose, fixture.Ships);
            Assert.Equal(expected, result);
        }
    }
}