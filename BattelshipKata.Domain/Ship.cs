namespace BattelshipKata.Domain
{
    public enum ShipType { None, Submarine, Destroyer, Cruiser, Battelship }
    public class Ship
    {
        public ShipType ShipType { get; set; }
        public int Size { get => (int)ShipType; }
        public Ship(ShipType shipType = ShipType.Submarine)
        {
            this.ShipType = shipType;
        }
    }
}