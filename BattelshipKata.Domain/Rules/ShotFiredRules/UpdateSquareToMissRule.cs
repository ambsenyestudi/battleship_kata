using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules.Base;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.ShotRules
{
    public class UpdateSquareToMissRule : BaseRule
    {
        
        private readonly IList<BoardSquare> squares;
        private readonly IEnumerable<Ship> ships;
        private readonly Position shotPosition;

        public UpdateSquareToMissRule(IList<BoardSquare> squares,
            IEnumerable<Ship> ships,
            Position shotPosition, int boardWith, Action action) : base(action)
        {
            this.squares = squares;
            this.ships = ships;
            this.shotPosition = shotPosition;
        }
        public UpdateSquareToMissRule(Board board, 
            Position shotPosition, 
            Action action) : this(board.BoardSquares, board.Fleet, shotPosition, board.Width, action)
        {
        }
        public override IRuleResult Eval()
        {
            var hitShips = ships.Where(sh => sh.HitRuleFactory(shotPosition).Eval().IsSuccess);
            ruleResult.IsSuccess = !hitShips.Any();
            if(ruleResult.IsSuccess)
            {
                return ruleResult;
            }
            return new RuleResult();

        }
    }
}