using System;

namespace BattelshipKata.Domain.Ships
{
    public enum ShipType { None, Submarine, Destroyer, Cruiser, Battelship }
    public enum ShipOrientation { Horizontal, Vertical }
    public class Ship
    {
        public ShipType ShipType { get; set; }
        public Rectangle BoundingBox { get; protected set; }
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

        public int Size { get =>Math.Max(BoundingBox.Width, BoundingBox.Height); }

        public Ship(ShipType shipType = ShipType.Submarine)
        {

            this.ShipType = shipType;
            InitBoundingBox(this.ShipType);
        }

        protected virtual void InitBoundingBox(ShipType shipType)
        {
            switch (shipType)
            {
                case ShipType.Battelship:
                    this.BoundingBox = Battleship.BattleshipBoundingBoxFactory();
                    break;
                case ShipType.Cruiser:
                    this.BoundingBox = Cruiser.CruiserBoundingBoxFactory();
                    break;
                case ShipType.Destroyer:
                    this.BoundingBox = Destroyer.DestroyerBoundingBoxFactory();
                    break;
                default:
                    this.BoundingBox = Submarine.SubmarineBoundingBoxFactory();
                    break;
            }
        }
    }
}