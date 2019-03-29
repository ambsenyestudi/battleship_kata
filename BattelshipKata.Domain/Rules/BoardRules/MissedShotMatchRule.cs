using BattelshipKata.Domain.BoardManagement;

namespace BattelshipKata.Domain.Rules.BoardRules
{
    public class MissedShotMatchRule : IMatchRule
    {
        private readonly BoardSquare square;

        public MissedShotMatchRule(BoardSquare square)
        {
            this.square = square;
        }

        public bool IsMatch()
        {
            return square.GameState == SquareGameState.Covered;
        }
    }
}