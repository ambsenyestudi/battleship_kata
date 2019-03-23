using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.Base;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Test.Rules.ShipRules
{
    public class UpdateShipHitsRule : BaseRule
    {
        private readonly IList<Ship> ships;
        private readonly Position shotPosition;
        public UpdateShipHitsRule(IList<Ship> ships,
            Position shotPosition) : base(() =>
              {
                  UpdateShipTaken(ships, shotPosition);
              })
        {
            this.ships = ships;
            this.shotPosition = shotPosition;
        }

        public override IRuleResult Eval()
        {
            var hitShips = ships.Where(sh => sh.HitRuleFactory(shotPosition).IsMatch());
            if (hitShips.Any())
            {
                return ruleResult;
            }
            return new RuleResult();
        }
        public static void UpdateShipTaken(IList<Ship> ships, Position shotPosition)
        {
            for (int i = 0; i < ships.Count; i++)
            {
                if (ships[i].HitRuleFactory(shotPosition).IsMatch())
                {
                    ships[i].UpdateShotsTaken(shotPosition);
                }
            }
        }
    }
}