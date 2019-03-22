namespace BattelshipKata.Domain.Ships
{
    public class Battleship:Ship
    {
        public Battleship():base(ShipType.Battelship)
        {
            InitBoundingBox();
        }
        private void InitBoundingBox()
        {
            this.BoundingBox = BattleshipBoundingBoxFactory();
        }
        public static Rectangle BattleshipBoundingBoxFactory()
        {
            var boundingBox = Rectangle.One;
            boundingBox.Width = 5;
            return boundingBox;
        }
    }
}
