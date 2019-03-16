namespace BattelshipKata.Domain.Rules.BoardRules
{
    public abstract class AInBoardRule
    {
        protected Ship ship;
        public AInBoardRule(Ship ship)
        {
            this.ship = ship;
        }
        protected (int, int) AddSizeToPosition()
        {
            var (x, y) = ship.Position;
            if (ship.ShipOrientation == ShipOrientation.Vertical)
            {
                y += (ship.Size - 1);
            }
            else
            {
                //defaults to horizontal
                x += (ship.Size - 1);
            }
            return (x, y);
        }
        public virtual bool IsMatch(Board board)
        {
            var (x, y) = ship.Position;
            var result = x >= 0 && y >= 0 && x < board.Size && y < board.Size;
            return result;
        }
    }
}