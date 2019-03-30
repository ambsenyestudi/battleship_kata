namespace BattelshipKata.Domain.Ships
{
    public class Carrier:Ship
    {
        public Carrier():base(ShipType.Carrier)
        {
            InitBoundingBox();
        }
        private void InitBoundingBox()
        {
            this.BoundingBox = CruiserBoundingBoxFactory();
        }
        public static Rectangle CruiserBoundingBoxFactory()
        {
            var boundingBox = Rectangle.One;
            boundingBox.Width = 5;
            return boundingBox;
        }
    }
}