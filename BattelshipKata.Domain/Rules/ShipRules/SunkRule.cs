using System;
using System.Linq;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Rules.Base;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.ShipRules
{
    public class SunkRule : BaseRule
    {
        private readonly Board board;
        private readonly Position shotPosition;

        public SunkRule(Board board,
            Position shotPosition,
            Action action) : base(action)
        {
            this.board = board;
            this.shotPosition = shotPosition;
        }
        public override IRuleResult Eval()
        {
            var lastAction = board.LastActionOutcome;

            ruleResult.IsSuccess = IsSinkShipMatch(lastAction, shotPosition);

            if (ruleResult.IsSuccess)
            {
                return ruleResult;
            }
            return new RuleResult();
        }

        private bool IsSinkShipMatch(ShotActionOutcome lastAction, Position pos)
        {
            if (lastAction != null && lastAction.Outcome == SquareDiscoveringOutCome.Hit)
            {
                var hitShip = lastAction.Ship;
                bool isSunkShip = IsSunkShip(hitShip, pos);
                return isSunkShip;
            }
            return false;
        }

        private bool IsSunkShip(Ship hitShip, Position pos)
        {
            var isHitShip = IsHitShip(hitShip, pos);
            var isSinking = false;
            if (isHitShip)
            {
                //NoShotsLeft
                isSinking = !hitShip.ShotsTaken.Where(sh => !sh.Item2).Any();
            }

            return isHitShip && isSinking;
        }
        private bool IsHitShip(Ship hitShip, Position pos)
        {
            var isHitShip = hitShip != null;
            if (isHitShip)
            {
                isHitShip &= hitShip.HitRuleFactory(pos).IsMatch();
            }
            return isHitShip;
        }
    }
}