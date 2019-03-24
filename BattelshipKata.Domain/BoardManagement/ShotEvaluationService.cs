using System;
using System.Collections.Generic;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.ShotRules;

namespace BattelshipKata.Domain.BoardManagement
{
    public class ShotEvaluationService
    {
        private readonly BoardUpdateService boardUpdateService;

        public ShotEvaluationService(BoardUpdateService boardUpdateService)
        {
            this.boardUpdateService = boardUpdateService;
        }
        public RulesEvaluator BuildShotRulesEvaluator(Board board, Position shotPosition)
        {
            var evaluator = new RulesEvaluator();
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
            return evaluator;
        }
        
    }
}