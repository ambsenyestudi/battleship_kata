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
            if (ship.MyProperty == ShipOrientation.Vertical)
            {
                y += ship.Size;
            }
            else
            {
                //defaults to horizontal
                x += ship.Size;
            }
            return (x, y);
        }
        public virtual bool IsMatch(Board board)
        {
            var (x, y) = ship.Position;
            var result = x < board.Size && y < board.Size;
            return result;
        }
    }
}