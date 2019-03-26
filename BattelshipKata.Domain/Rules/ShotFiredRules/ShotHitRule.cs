using System;
using System.Linq;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Rules.Base;

namespace BattelshipKata.Domain.Rules.ShotRules
{
    public class ShotHitRule : BaseRule
    {
        private readonly Board board;
        private readonly Position shotPosition;

        public ShotHitRule(Board board, 
            Position shotPosition, 
            Action action):base(action)
        {
            this.board = board;
            this.shotPosition = shotPosition;
        }
        public override IRuleResult Eval()
        {
            var hitShips = board.Fleet.Where(sh => sh.HitRuleFactory(shotPosition).Eval().IsSuccess);
            ruleResult.IsSuccess = hitShips.Any();
            if (ruleResult.IsSuccess)
            {
                return ruleResult;
            }
            return new RuleResult();
        }
    }
}