
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattelshipKata.Domain.BoardManagement
{
    public class BoardCheckingService
    {
        public SquareDiscoveringOutCome FireAway(IEnumerable<BoardSquare> squares,Position shotPosition)
        {
            var currentSquare = squares.First(); 
            if(currentSquare.GameState == SquareGameState.Covered)
            {
                var outcome = currentSquare.Discover();
                return outcome;
            }
            return SquareDiscoveringOutCome.AlreadyHit;
        }
    }
}