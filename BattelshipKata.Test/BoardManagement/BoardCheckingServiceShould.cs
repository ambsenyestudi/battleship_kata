using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.Ships;
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
            var size = 1;
            fixture.InitEmptyBoard(size, size);
            var expected = SquareDiscoveringOutCome.AlreadyHit;
            fixture.Squares[0].Discover(null);
            var result = fixture.Sut.FireAway(fixture.Squares, Position.Zero, fixture.Ships, size);

            Assert.Equal(expected, result);
        }
        [Fact]
        public void Miss_when_empty_square()
        {
            var size = 1;
            fixture.InitEmptyBoard(size, size);
            var expected = SquareDiscoveringOutCome.Miss;
            var result = fixture.Sut.FireAway(fixture.Squares, Position.Zero, fixture.Ships, size);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Hit_when_full_square()
        {
            var boardSize = 1;
            var pos = fixture.InitSubmarineBoard(boardSize);
            var expected = SquareDiscoveringOutCome.Hit;
            var result = fixture.Sut.FireAway(fixture.Squares, pos, fixture.Ships, boardSize);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Sunk_when_submarine_hit()
        {
            var subPose = fixture.InitSubmarineBoard(3);
            var expected = SquareDiscoveringOutCome.SunkedShip;
            var result = fixture.Sut.FireAway(fixture.Squares, subPose, fixture.Ships, 3);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Sunk_when_battleship_hit_4time()
        {
            int size = 4;
            var (battleShipPose, battleShipEndPose) = fixture.InitBattleshipBoard(size);
            var expected = SquareDiscoveringOutCome.SunkedShip;
            var battleShipPoses = fixture.GeneratePostionsFromToPoints(battleShipPose, battleShipEndPose, size);
            var result = SquareDiscoveringOutCome.None;
            foreach (var pose in battleShipPoses)
            {
                var hitShips = fixture.Sut.CheckShipsHit(pose, fixture.Ships);
                if(hitShips.Any())
                {
                    var currShip = hitShips.First();
                    var index = fixture.Ships.IndexOf(currShip);
                    fixture.Ships[index].UpdateShotsTaken(pose);
                }
                if(pose == battleShipPoses.Last())
                {
                    result = fixture.Sut.FireAway(fixture.Squares, pose, fixture.Ships,size);
                }
            }
            
            Assert.Equal(expected, result);
        }
        
    }
}