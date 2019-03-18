using System;
using Xunit;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;

namespace BattelshipKata.Test.BoardManagement
{
    public class BoardShould
    {

        [Fact]
        public void Have_ships()
        {
            var board = new Board();
            Assert.True(board.ShipCount > 0);
        }
        [Fact]
        public void Have_a_battleship()
        {
            var board = new Board();
            Assert.True(board.BattleShipCount == 1);
        }
        [Fact]
        public void Have_two_cruisers()
        {
            var board = new Board();
            Assert.True(board.CruiserCount == 2);
        }
        [Fact]
        public void Have_three_destroyers()
        {
            var board = new Board();
            Assert.True(board.DestroyerCount == 3);
        }
        [Fact]
        public void Have_five_Submarines()
        {
            var board = new Board();
            Assert.True(board.SubmarineCount == 5);
        }
    }
}
