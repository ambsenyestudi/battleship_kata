using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.ShipRules;

namespace BattelshipKata.Domain.Ships
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
        public void UpdateShotsTaken(Position pos)
        {
            var hits = shotsTaken.Where(sq=>sq.Item1.X == pos.X &&sq.Item1.Y == pos.Y);
            if(hits.Any())
            {
                var index = shotsTaken.IndexOf(hits.First());
                var (shotPos, shotVal) = shotsTaken[index];
                shotsTaken[index] = (shotPos, true);
            }
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
            this.ShotsTaken = BoundingBox.GetAllRectanglePositions().Select(pos => (pos, false)).ToList();
        }
        public IMatchRule SunkRuleFactory()
        {
            return new SunkRule(this);   
        }
        public IMatchRule HitRuleFactory(Position shotPos)
        {
            return new HitRule(this, shotPos);
        }
    }
}