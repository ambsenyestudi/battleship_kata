using System;
using Xunit;
using BattelshipKata.Domain;

namespace BattelshipKata.Test
{
    public class BattleshipShould
    {
        
        [Fact]
        public void Exist()
        {
            var battleShip = new Battelship();
            Assert.NotNull(battleShip);
        }
        [Fact]
        public void Have_board_size()
        {
            var battleShip = new Battelship();
            Assert.True(battleShip.Size>0);
        }
        [Fact]
        public void Have_players()
        {
            var battleShip = new Battelship();
            Assert.True(battleShip.PlayerCount>0);
        }
        [Fact]
        public void Have_ships()
        {
            var battleShip = new Battelship();
            Assert.True(battleShip.ShipCount>0);
        }
    }
}
