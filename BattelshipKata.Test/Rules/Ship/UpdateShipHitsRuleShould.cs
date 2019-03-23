using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Ships;
using BattelshipKata.Test.Rules.ShipRules;
using Xunit;
using BattelshipKata.Test.Helpers;

namespace BattelshipKata.Test.Rules.BoardManagement
{
    public class UpdateShipsHitRuleShould
    {
        private IRule UpdateShipHitsRuleFactory(IList<Ship> ships, Position pos) =>
            new UpdateShipHitsRule(ships, pos);
        private IEnumerable<IRule> UpdateShipHitsRuleFromPosListFactory(IList<Ship> ships,
            IEnumerable<Position> positions) =>
                positions.Select(pos => UpdateShipHitsRuleFactory(ships, pos));
        
        private void ExecuteOnSuccess(IEnumerable<IRule> rules)
        {
            foreach (var rule in rules)
            {
                var evalutor = rule.Eval();
                if (evalutor.IsSuccess)
                {
                    evalutor.Execute();
                }
            }
        }
        
        
        [Fact]
        public void Update_ship_when_hit()
        {
            //Given
            var ships = TestFactory.GetSingleSumbarineAsShips();
            var rules = UpdateShipHitsRuleFromPosListFactory(ships, new List<Position> { Position.Zero });
            var expected = 1;
            //When
            ExecuteOnSuccess(rules);
            //Then
            var sub = ships.First();
            var shotCount = sub.ShotsTaken.Where((sht) => sht.Item2).Count();
            Assert.Equal(expected, shotCount);
        }
        [Fact]
        public void Sink_ship_when_hit_twice()
        {
            //Given
            var ships = TestFactory.GetSingleSumbarineAsShips();
            var positions = TestFactory.GetPositionsFromIndexFactory(2,2);
            var rules = UpdateShipHitsRuleFromPosListFactory(ships, positions);
            //When
            ExecuteOnSuccess(rules);
            //Then
            var isAllShotsTaken = ships.First().ShotsTaken.All(sh=>sh.Item2);
            Assert.True(isAllShotsTaken);
        }
    }
}