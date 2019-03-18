using System;

namespace BattelshipKata.Domain.BoardManagement
{
    public enum SquareGameState { None, Covered, Miss, Hit}
    public enum SquareDiscoveringOutCome {None, AlreadyHit, Miss, Hit, SunkedShip}
    public class BoardSquare
    {
        public SquareGameState GameState { get; set; }
        public bool IsFull { get; set; }
        public SquareDiscoveringOutCome Discover()
        {
            if(IsFull)
            {
                GameState = SquareGameState.Hit;
                return SquareDiscoveringOutCome.Hit;
            }
            GameState = SquareGameState.Miss;
            return SquareDiscoveringOutCome.Miss;
        }
    }
}