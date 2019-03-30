using System;
using Xunit;
using BattelshipKata.Domain;
using BattelshipKata.Domain.Ships;

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
        public void Size_3_when_subarine()
        {
            var ship = new Submarine();
            var expected = 3;
            Assert.Equal(expected, ship.Size);
        }
        [Fact]
        public void Size_2_when_destroyer()
        {
            var ship = new Destroyer();
            var expected = 2;
            Assert.Equal(expected, ship.Size);
        }
        [Fact]  
        public void Size_5_when_carrier()
        {
            var ship = new Carrier();
            var expected = 5;
            Assert.Equal(expected, ship.Size);
        }
        [Fact]
        public void Size_4_when_battleship()
        {
            var ship = new Battleship();
            var expected = 4;
            Assert.Equal(expected, ship.Size);
        }
    }
}
