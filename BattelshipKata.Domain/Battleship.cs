using System;

namespace BattelshipKata.Domain
{
    public class Battelship
    {
        public int Size { get; set; }
        public int PlayerCount { get; set; }
        public int ShipCount { get; set; }

        public Battelship(int size = 10, int shipCount = 10, int playerCount = 2)
        {
            this.Size = size;
            this.ShipCount = shipCount;
            this.PlayerCount = playerCount;
        }
    }
}
