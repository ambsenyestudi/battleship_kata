namespace BattelshipKata.Domain.Rules.BoardRules
{
    public abstract class AInBoardRule
    {
        protected Ship ship;
        public AInBoardRule(Ship ship)
        {
            this.ship = ship;
        }
        
        public virtual bool IsMatch(Board board)
        {
            //Refactor this to rectangle

            var x = ship.Position.X;
            var y = ship.Position.Y;
            var result = x >= 0 && y >= 0 && x < board.Size && y < board.Size;
            return result;
        }
    }
}