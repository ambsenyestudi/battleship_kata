using System;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.BoardRules;
using BattelshipKata.Domain.Rules.ShipRules;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.BoardManagement
{
    public enum SquareGameState { None, Covered, Miss, Hit}
    public enum SquareDiscoveringOutCome {None, AlreadyHit, Miss, Hit, SunkedShip}
    public class BoardSquare
    {
        public SquareGameState GameState { get; private set; }
        public BoardSquare()
        {
            Reset();
        }
        public SquareDiscoveringOutCome Discover(IMatchRule hitRule = null, IMatchRule sunkRule = null)
        {

            if(hitRule !=null && hitRule.IsMatch())
            {
                if(sunkRule !=null && sunkRule.IsMatch())
                {
                    GameState = SquareGameState.Hit;
                    return SquareDiscoveringOutCome.SunkedShip;
                }
                GameState = SquareGameState.Hit;
                return SquareDiscoveringOutCome.Hit;
            }
            GameState = SquareGameState.Miss;
            return SquareDiscoveringOutCome.Miss;
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