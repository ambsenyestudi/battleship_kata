using System;
using System.Collections.Generic;
using System.Linq;

namespace BattelshipKata.Domain
{
    public enum ShipType { None, Submarine, Destroyer, Cruiser, Battelship }
    public enum ShipOrientation { Horizontal, Vertical }
    public class Ship
    {
        public ShipType ShipType { get; set; }
        public Rectangle BoundingBox { get; set; }
        private List<(Position, bool)> shotsTaken;
        public List<(Position, bool)> ShotsTaken
        {
            get { return shotsTaken;}
            set { shotsTaken = value;}
        }
        
        public Position Position
        {
            get => BoundingBox.Position;
            set
            {
                BoundingBox.Position = value;
                RecalculateShots(BoundingBox);
            }
        }
        public bool IsSunken
        {
            get => ShotsTaken.Count == ShotsTaken.Where((item)=>item.Item2).Count();
        }

        private void RecalculateShots(Rectangle boundingBox)
        {
            if(shotsTaken == null)
            {
                shotsTaken = new List<(Position, bool)>();
            }
            var rectPoses = BoundingBox.GetAllRectanglePositions();
            if(shotsTaken.Any())
            {
                for (int i = 0; i < shotsTaken.Count; i++)
                {
                    shotsTaken[i] = (rectPoses[i],shotsTaken[i].Item2);
                }
            }
            else
            {
                
                foreach (var pose in rectPoses)
                {
                    shotsTaken.Add((pose, false));
                }
                
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
                RecalculateShots(BoundingBox);
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