using System;
using System.Collections.Generic;
using System.Linq;

namespace BattelshipKata.Domain
{
    public class Battelship
    {
        public int BattleShipCount { get => Ships.Where(sh => sh.ShipType == ShipType.Battelship).Count(); }
        public int CruiserCount { get => Ships.Where(sh => sh.ShipType == ShipType.Cruiser).Count(); }
        public int DestroyerCount { get => Ships.Where(sh => sh.ShipType == ShipType.Destroyer).Count(); }
        public int SubmarineCount { get => Ships.Where(sh => sh.ShipType == ShipType.Submarine).Count(); }
        public int Size { get; set; }
        public int PlayerCount { get; set; }
        public int ShipCount { get => Ships.Count(); }
        public IEnumerable<Ship> Ships { get; set; }

        public Battelship(int size = 10, int shipCount = 11, int playerCount = 2)
        {
            this.Size = size;
            this.PlayerCount = playerCount;
            this.InitShips(shipCount);
        }

        private void InitShips(int shipCount)
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
                    ships.Add(new Ship(ShipType.Cruiser));

                }
                else if (i> shipCount / 2)
                {
                    ships.Add(new Ship());
                }
                else
                {
                    ships.Add(new Ship(ShipType.Destroyer));
                }

            }

            Ships = ships;
        }
    }
}
