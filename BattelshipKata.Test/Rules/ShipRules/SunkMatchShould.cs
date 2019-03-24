using BattelshipKata.Domain;
using BattelshipKata.Domain.Rules.ShipRules;
using BattelshipKata.Domain.Ships;
using Xunit;

namespace BattelshipKata.Test.Rules.ShotRules
{
    public class SunkMatchShould
    {
        [Fact]
        public void Sink_succesfully_when_last_shot()
        {
            //Given
            var ship = new Submarine();
            ship.UpdateShotsTaken(new Position { X = 1, Y = 0 });
            var rule = new SunkRule(ship, Position.Zero, null);
            //When
            var result = rule.Eval();
            //Then
            Assert.True(result.IsSuccess);
        }
        [Fact]
        public void Not_sink_succesfully_when_missing_shots()
        {
            //Given
            var ship = new Submarine();
             var rule = new SunkRule(ship, Position.Zero, null);
            //When
            var result = rule.Eval();
            //Then
            Assert.False(result.IsSuccess);
        }
    }
}