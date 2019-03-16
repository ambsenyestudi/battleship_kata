namespace BattelshipKata.Domain
{
    public enum ShipType { None, Submarine, Destroyer, Cruiser, Battelship }
    public enum ShipOrientation {Horizontal, Vertical}
    public class Ship
    {
        public ShipType ShipType { get; set; }
        public (int, int) Position {get; set; }
        public ShipOrientation MyProperty { get; set; }
        public int Size { get => (int)ShipType; }

        public Ship(ShipType shipType = ShipType.Submarine)
        {
            this.ShipType = shipType;
        }
    }
}