using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.BoardRules;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.BoardManagement
{
    public class BoardService
    {
        public IMatchRule InBoardRuleFactory(Board board, Ship ship)
        {
            return new InBoardRule(board, ship);
        }
        public IMatchRule SpaceShipRuleFactory(Board board, IEnumerable<Ship> ships)
        {
            return new SpacedShipsRule(board, ships);
        }
        public bool IsInBoard(IEnumerable<IMatchRule> rules)
        {
            return rules.Where(r=>!r.IsMatch()).Count() == 0;
        }
    }
}