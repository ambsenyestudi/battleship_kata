using System;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.BoardRules;
using BattelshipKata.Domain.Rules.ShipRules;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.BoardManagement
{
    public enum SquareGameState { None, Covered, Miss, Hit }
    public enum SquareDiscoveringOutCome { None, AlreadyHit, Miss, Hit, SunkedShip }
    public class BoardSquare
    {
        public SquareGameState GameState { get; private set; }
        public BoardSquare()
        {
            Reset();
        }
        public void Discover(SquareDiscoveringOutCome outcome)
        {
            if(outcome !=SquareDiscoveringOutCome.AlreadyHit)
            {
                GameState = MapOutcome(outcome);
            }
        }

        private SquareGameState MapOutcome(SquareDiscoveringOutCome outcome)
        {
            var result = SquareGameState.Covered;
            switch (outcome)
            {
                case SquareDiscoveringOutCome.SunkedShip:
                    result = SquareGameState.Hit;
                    break;
                case SquareDiscoveringOutCome.Hit:
                    result = SquareGameState.Hit;
                    break;
                case SquareDiscoveringOutCome.Miss:
                    result = SquareGameState.Miss;
                    break;
                default:
                    result = SquareGameState.None;
                    break;
            }
            return result;
        }

        public void Reset()
        {
            GameState = SquareGameState.Covered;
        }
        public IMatchRule MissedShotRuleFactory()
        {
            return new MissedShotRule(this);
        }
    }
}