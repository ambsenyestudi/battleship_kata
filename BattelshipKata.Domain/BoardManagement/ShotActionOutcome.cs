using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.BoardManagement
{
    public class ShotActionOutcome
    {
        public SquareDiscoveringOutCome Outcome { get; set; }
        public Ship Ship { get; set; }
    }
}