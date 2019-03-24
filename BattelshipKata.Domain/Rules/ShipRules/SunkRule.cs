using System;
using System.Linq;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Rules.Base;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.ShipRules
{
    public class SunkRule : BaseRule
    {
        private readonly Ship ship;
        private readonly Position shotPosition;
    
        public SunkRule(Ship ship, 
            Position shotPosition, 
            Action action):base(action)
        {
            this.ship = ship;
            this.shotPosition = shotPosition;
        }
        public override IRuleResult Eval()
        {
            ship.UpdateShotsTaken(shotPosition);
            //NoShotsLeft
            var isSinking = ! ship.ShotsTaken.Where(sh=>!sh.Item2).Any();
            ruleResult.IsSuccess = isSinking;
            if(ruleResult.IsSuccess)
            {
                return ruleResult;
            }
            return new RuleResult();
        }
    }
}