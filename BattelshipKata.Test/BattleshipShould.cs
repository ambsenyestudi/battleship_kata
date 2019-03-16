using System;
using Xunit;
using BattelshipKata.Domain;

namespace BattelshipKata.Test
{
    public class BattleshipShould
    {
        [Fact]
        public void DummyTest()
        {
            Assert.True(true);
        }
        [Fact]
        public void Exist()
        {
            var battleShip = new Battelship();
            Assert.NotNull(battleShip);
        }
        [Fact]
        public void HaveSize()
        {
            var battleShip = new Battelship();
            Assert.True(battleShip.Size>0);
        }
    }
}
