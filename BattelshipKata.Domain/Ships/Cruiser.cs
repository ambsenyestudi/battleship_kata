namespace BattelshipKata.Domain.Ships
{
    public class Cruiser:Ship
    {
        public Cruiser():base(ShipType.Cruiser)
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
            boundingBox.Width = 4;
            return boundingBox;
        }
    }
}