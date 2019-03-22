namespace BattelshipKata.Domain.Ships
{
    public class Destroyer:Ship
    {
        public Destroyer():base(ShipType.Destroyer)
        {
            InitBoundingBox();
        }
        private void InitBoundingBox()
        {
            this.BoundingBox = DestroyerBoundingBoxFactory();
        }
        public static Rectangle DestroyerBoundingBoxFactory()
        {
            var boundingBox = Rectangle.One;
            boundingBox.Width = 3;
            return boundingBox;
        }
    }
}