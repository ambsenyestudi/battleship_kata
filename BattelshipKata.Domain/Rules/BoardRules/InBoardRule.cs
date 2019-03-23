using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.BoardRules
{
    public class InBoardRule : AInBoardRule, IMatchRule
    {
        private readonly Board board;

        public InBoardRule(Board board, Ship ship) : base(ship)
        {
            this.board = board;
        }
        public bool IsMatch()
        {
            var result = base.IsMatch(board);
            if (result && ship.Size > 1)
            {
                var endPosition = ship.BoundingBox.FigureEndPosition();
                result = endPosition.X < board.Size && endPosition.Y < board.Size;
            }
            return result;
        }
    }
}