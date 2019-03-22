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
        public void Size_two_when_subarine()
        {
            var ship = new Submarine();
            var expected = 2;
            Assert.Equal(expected, ship.Size);
        }
        [Fact]
        public void Size_three_when_destroyer()
        {
            var ship = new Destroyer();
            var expected = 3;
            Assert.Equal(expected, ship.Size);
        }
        [Fact]  
        public void Size_four_when_cruser()
        {
            var ship = new Cruiser();
            var expected = 4;
            Assert.Equal(expected, ship.Size);
        }
        [Fact]
        public void Size_five_when_battleship()
        {
            var ship = new Battleship();
            var expected = 5;
            Assert.Equal(expected, ship.Size);
        }
    }
}
