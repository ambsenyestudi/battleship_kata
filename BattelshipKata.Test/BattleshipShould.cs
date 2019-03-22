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
            var battleShip = new BattelshipGame();
            Assert.NotNull(battleShip);
        }
        [Fact]
        public void Have_board_size()
        {
            var battleShip = new BattelshipGame();
            Assert.True(battleShip.BoardSize > 0);
        }
        [Fact]
        public void Have_players()
        {
            var battleShip = new BattelshipGame();
            Assert.True(battleShip.PlayerCount > 0);
        }
    }
}
