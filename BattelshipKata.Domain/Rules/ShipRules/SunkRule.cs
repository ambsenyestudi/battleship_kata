
using System.Linq;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.ShipRules
{
    public class SunkRule : IMatchRule
    {
        private readonly Ship ship;

        public SunkRule(Ship ship)
        {
            this.ship = ship;
        }
        public bool IsMatch()
        {
            return ship.ShotsTaken.Count == ship.ShotsTaken.Where((item)=>item.Item2).Count();
        }
    }
}