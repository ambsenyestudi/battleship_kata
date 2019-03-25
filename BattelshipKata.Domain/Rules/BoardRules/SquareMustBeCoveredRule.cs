using System;
using System.Collections.Generic;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules.Base;

namespace BattelshipKata.Domain.Rules.BoardRules
{
    public class SquareMustBeCoveredRule : BaseRule
    {
        private readonly IList<BoardSquare> squares;
        private Position shotPosition;
        private readonly int boardWidth;

        public SquareMustBeCoveredRule(IList<BoardSquare> squares,
            Position shotPosition, 
            int boardWidth,
            Action actionToBeExecuted) : base(actionToBeExecuted)
        {
            this.squares = squares;
            this.shotPosition = shotPosition;
            this.boardWidth = boardWidth;
        }

        public override IRuleResult Eval()
        {
            var index = shotPosition.ToBoardIndex(boardWidth);
            ruleResult.IsSuccess = squares[index].GameState == SquareGameState.Covered;
            return ruleResult;
        }
    }
}