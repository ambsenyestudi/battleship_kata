using System;
using System.Collections.Generic;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.BoardRules;
using BattelshipKata.Domain.Rules.ShipRules;
using BattelshipKata.Domain.Rules.ShotRules;

namespace BattelshipKata.Domain.BoardManagement
{
    public class ShotEvaluationService
    {
        private readonly IBoardUpdateService boardUpdateService;

        public ShotEvaluationService(IBoardUpdateService boardUpdateService)
        {
            this.boardUpdateService = boardUpdateService;
        }
        public RulesEvaluator BuildShotRulesEvaluator(Board board, Position shotPosition)
        {
            var evaluator = new RulesEvaluator();
            evaluator.Eval(
                new SquareMustBeCoveredRule(board.BoardSquares, 
                    shotPosition, board.Width, null)
            );
            evaluator.OtherwiseDo(()=>boardUpdateService.UpdateAlreadyHitOutcome(board));
            evaluator.Eval(
                new UpdateSquareToMissRule(board, shotPosition,
                    ()=>boardUpdateService.UpdateMissShot(board,shotPosition)
                )
            );
            evaluator.OtherwiseEval(
                new ShotHitRule(board, shotPosition, 
                    ()=>boardUpdateService.UpdateFleetAndBoardHits(board,shotPosition)
                )
            );
            evaluator.Eval(
                new SunkRule(board, shotPosition,
                    ()=>boardUpdateService.UpdateSunkOutcome(board)
                )
            );
            return evaluator;
        }
        
    }
}