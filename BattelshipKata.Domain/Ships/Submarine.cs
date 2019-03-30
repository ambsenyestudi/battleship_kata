namespace BattelshipKata.Domain.Ships
{
    public class Submarine:Ship
    {
        public Submarine():base(ShipType.Submarine)
        {
            InitBoundingBox();
        }
        private void InitBoundingBox()
        {
            this.BoundingBox = SubmarineBoundingBoxFactory();
        }
        public static Rectangle SubmarineBoundingBoxFactory()
        {
            var boundingBox = Rectangle.One;
            boundingBox.Width = 3;
            return boundingBox;
        }
    }
}