using BattelshipKata.Domain;

namespace BattelshipKata.Domain.Rules.BoardRules
{
    public class InBoardRule : AInBoardRule
    {
        private readonly Board board;

        public InBoardRule(Ship ship, Board board) : base(ship)
        {
            this.board = board;
        }
        public bool IsMatch()
        {
            var result = base.IsMatch(board);
            if (result && ship.Size > 1)
            {
                var (x, y) = base.AddSizeToPosition();
                result = x < board.Size && y < board.Size;
            }
            return result;
        }
    }
}