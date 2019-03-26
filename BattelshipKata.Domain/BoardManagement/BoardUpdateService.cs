using System;
using System.Collections.Generic;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.BoardManagement
{
    public class BoardUpdateService : IBoardUpdateService
    {
        public void UpdateMissShot(Board board, Position shotPosition)
        {
            board.LastActionOutcome = new ShotActionOutcome { Outcome = SquareDiscoveringOutCome.Miss };
            DiscoverSquareFromPoseAndRule(board, shotPosition);
        }
        public void UpdateFleetAndBoardHits(Board board, Position shotPosition)
        {
            //what if there was more than one hit
            for (int i = 0; i < board.Fleet.Count; i++)
            {
                var hitRule = board.Fleet[i].HitRuleFactory(shotPosition);
                if (hitRule.IsMatch())
                {
                    board.Fleet[i].UpdateShotsTaken(shotPosition);
                    board.LastActionOutcome = new ShotActionOutcome { Outcome = SquareDiscoveringOutCome.Hit, Ship = board.Fleet[i] };
                    DiscoverSquareFromPoseAndRule(board, shotPosition);
                }
            }
        }
        private void DiscoverSquareFromPoseAndRule(Board board, Position shotPosition)
        {
            var boardWidth = board.Width;
            var index = shotPosition.ToBoardIndex(boardWidth);
            board.BoardSquares[index].Discover(board.LastActionOutcome.Outcome);
        }
        public void ResetOutcome(Board board)
        {
            UpdateOutcome(board, new ShotActionOutcome { Outcome = SquareDiscoveringOutCome.None });
        }
        public void UpdateAlreadyHitOutcome(Board board)
        {
            UpdateOutcome(board, new ShotActionOutcome { Outcome = SquareDiscoveringOutCome.AlreadyHit });
        }
        public void UpdateOutcome(Board board, ShotActionOutcome outcome)
        {
            board.LastActionOutcome = outcome;
        }

        public void UpdateSunkOutcome(Board board)
        {
            var newOutcome = new ShotActionOutcome
            {
                Outcome = SquareDiscoveringOutCome.AlreadyHit,
                Ship = board.LastActionOutcome.Ship
            };
            UpdateOutcome(board, newOutcome);
        }
    }
}