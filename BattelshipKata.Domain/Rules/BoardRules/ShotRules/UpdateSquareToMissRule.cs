using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules.Base;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.BoardRules.ShotRules
{
    public class UpdateSquareToMissRule : BaseRule
    {
        private readonly IList<BoardSquare> squares;
        private readonly IEnumerable<Ship> ships;
        private readonly Position shotPosition;

        public UpdateSquareToMissRule(IList<BoardSquare> squares,
            IEnumerable<Ship> ships,
            Position shotPosition, int boardWith) : base(() =>
            {
                DiscoverPosition(squares,ships, shotPosition, boardWith);
            })
        {
            this.squares = squares;
            this.ships = ships;
            this.shotPosition = shotPosition;
        }
        public override IRuleResult Eval()
        {
            var hitShipsCount = ships.Where(sh =>sh.HitRuleFactory(shotPosition).IsMatch());
            if(hitShipsCount.Any())
            {
                return new RuleResult();
            }
            return ruleResult;

        }
        public static void DiscoverPosition(IList<BoardSquare> squares,
            IEnumerable<Ship> ships,
            Position shotPosition, int boardWidth)
        {
            var index = shotPosition.ToBoardIndex(boardWidth);
                squares[index].Discover();
        }
    }
}