using System;
using Xunit;
using BattelshipKata.Domain;

namespace BattelshipKata.Test
{
    public class ShipShould
    {

        [Fact]
        public void Have_size()
        {
            var ship = new Ship();
            Assert.True(ship.Size > 0);
        }
        [Fact]
        public void Size_one_when_subarine()
        {
            var ship = new Ship(ShipType.Submarine);
            var expected = 1;
            Assert.Equal(expected, ship.Size);
        }
        [Fact]
        public void Size_two_when_destroyer()
        {
            var ship = new Ship(ShipType.Destroyer);
            var expected = 2;
            Assert.Equal(expected, ship.Size);
        }
        [Fact]  
        public void Size_thre_when_cruser()
        {
            var ship = new Ship(ShipType.Cruiser);
            var expected = 3;
            Assert.Equal(expected, ship.Size);
        }
        [Fact]
        public void Size_thre_when_battleship()
        {
            var ship = new Ship(ShipType.Battelship);
            var expected = 4;
            Assert.Equal(expected, ship.Size);
        }
    }
}
