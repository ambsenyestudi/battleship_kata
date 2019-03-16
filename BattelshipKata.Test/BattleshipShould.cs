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
            Assert.True(battleShip.Size > 0);
        }
        [Fact]
        public void Have_players()
        {
            var battleShip = new Battelship();
            Assert.True(battleShip.PlayerCount > 0);
        }
        [Fact]
        public void Have_ships()
        {
            var battleShip = new Battelship();
            Assert.True(battleShip.ShipCount > 0);
        }
        //Refactor this to board
        [Fact]
        public void Have_a_battleship()
        {
            var battleShip = new Battelship();
            Assert.True(battleShip.BattleShipCount == 1);
        }
        [Fact]
        public void Have_two_cruisers()
        {
            var battleShip = new Battelship();
            Assert.True(battleShip.CruiserCount == 2);
        }
        [Fact]
        public void Have_three_destroyers()
        {
            var battleShip = new Battelship();
            Assert.True(battleShip.DestroyerCount == 3);
        }
        [Fact]
        public void Have_five_Submarines()
        {
            var battleShip = new Battelship();
            Assert.True(battleShip.SubmarineCount == 5);
        }
    }
}
