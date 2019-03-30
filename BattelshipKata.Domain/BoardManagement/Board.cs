using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.BoardManagement
{
    public class Board
    {
        private int size;
        public int Size
        {
            get { return size; }
            set
            {
                size = value;
                Width = size;
                Height = size;
            }
        }

        public int BattleShipCount { get => Fleet.Where(sh => sh.ShipType == ShipType.Battelship).Count(); }
        public int CruiserCount { get => Fleet.Where(sh => sh.ShipType == ShipType.Carrier).Count(); }
        public int DestroyerCount { get => Fleet.Where(sh => sh.ShipType == ShipType.Destroyer).Count(); }
        public int SubmarineCount { get => Fleet.Where(sh => sh.ShipType == ShipType.Submarine).Count(); }

        public int ShipCount { get => Fleet.Count(); }
        public IList<Ship> Fleet { get; set; }
        public BoardService BoardService { get; set; }
        public List<BoardSquare> BoardSquares { get; set; }
        public ShotActionOutcome LastActionOutcome { get; set; }
        //Todo refactor into bounding box
        public int Width { get; private set; }
        public int Height { get; private set; }
        private Rectangle bounds;
        public Rectangle Bounds
        {
            get
            {
                if(bounds == null)
                {
                    bounds = new Rectangle
                    {
                        Position = Position.Zero,
                        Width = this.Width,
                        Height = this.Height
                    };
                }
                return bounds;
            }
        }

        public Board(int size, IList<Ship> ships)
        {
            this.Size = size;
            this.Fleet = ships;
            BoardService = new BoardService();
        }
        public Board(int size = 10, int shipCount = 11) : this(size, ShipsFactory(shipCount))
        {
        }

        private static IList<Ship> ShipsFactory(int shipCount)
        {
            var ships = new List<Ship>();
            for (int i = 0; i < shipCount; i++)
            {
                if (i < shipCount / 10)
                {
                    ships.Add(new Ship(ShipType.Battelship));
                }
                else if (i < shipCount / 3)
                {
                    ships.Add(new Ship(ShipType.Carrier));

                }
                else if (i > shipCount / 2)
                {
                    ships.Add(new Ship());
                }
                else
                {
                    ships.Add(new Ship(ShipType.Destroyer));
                }

            }

            return ships;
        }
    }
}