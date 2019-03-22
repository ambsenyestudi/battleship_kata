using System;
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
        public SquareDiscoveringOutCome Discover(Ship ship)
        {

            if(ship!=null)
            {
                if(ship.IsSunken)
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
    }
}