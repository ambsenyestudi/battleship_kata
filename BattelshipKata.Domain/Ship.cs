namespace BattelshipKata.Domain
{
    public enum ShipType { None, Submarine, Destroyer, Cruiser, Battelship }
    public enum ShipOrientation { Horizontal, Vertical }
    public class Ship
    {
        public ShipType ShipType { get; set; }
        public Rectangle BoundingBox { get; set; }
        public Position Position
        {
            get => BoundingBox.Position;
            set
            {
                BoundingBox.Position = value;
            }
        }
        private ShipOrientation shipOrientation;
        public ShipOrientation ShipOrientation
        {
            get { return shipOrientation; }
            set
            {
                if (shipOrientation != value)
                {
                    BoundingBoxSwichHeightAndWidth();
                }
                shipOrientation = value;
            }

        }

        private void BoundingBoxSwichHeightAndWidth()
        {
            int w = BoundingBox.Height;
            int h = BoundingBox.Width;
            BoundingBox.Width = w;
            BoundingBox.Height = h;
        }

        public int Size { get => (int)ShipType; }

        public Ship(ShipType shipType = ShipType.Submarine)
        {

            this.ShipType = shipType;
            InitBoundingBox(this.ShipType);
        }

        private void InitBoundingBox(ShipType shipType)
        {
            var boundingBox = Rectangle.One;
            switch (shipType)
            {
                case ShipType.Battelship:
                    boundingBox.Width = 4;
                    break;
                case ShipType.Cruiser:
                    boundingBox.Width = 3;
                    break;
                case ShipType.Destroyer:
                    boundingBox.Width = 2;
                    break;
                default:
                    boundingBox = Rectangle.One;
                    break;
            }
            this.BoundingBox = boundingBox;
        }
    }
}