using BattelshipKata.Domain.BoardManagement;

namespace BattelshipKata.Domain.Rules.BoardRules
{
    public class MissedShotRule : IMatchRule
    {
        private readonly BoardSquare square;

        public MissedShotRule(BoardSquare square)
        {
            this.square = square;
        }

        public bool IsMatch()
        {
            return square.GameState == SquareGameState.Covered;
        }
    }
}