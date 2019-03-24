using System;
using System.Collections.Generic;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.BoardManagement
{
    public class BoardUpdateService:IBoardUpdateService
    {
        public void UpdateMissShot(Board board, Position shotPosition)
        {
            DiscoverSquareFromPoseAndRule(board, shotPosition);
        }
        public void UpdateFleetAndBoardHits(Board board, Position shotPosition)
        {
            
            for (int i = 0; i < board.Fleet.Count; i++)
            {
                var hitRule = board.Fleet[i].HitRuleFactory(shotPosition);
                if (hitRule.IsMatch())
                {
                    board.Fleet[i].UpdateShotsTaken(shotPosition);
                    DiscoverSquareFromPoseAndRule(board, shotPosition, hitRule);
                }
            }
        }
        private void DiscoverSquareFromPoseAndRule(Board board, Position shotPosition, IMatchRule hitRule = null, IMatchRule sunkRule = null)
        {
            var boardWidth = board.Width;
            var index = shotPosition.ToBoardIndex(boardWidth);
            board.BoardSquares[index].Discover(hitRule, sunkRule);
        }
    }
}