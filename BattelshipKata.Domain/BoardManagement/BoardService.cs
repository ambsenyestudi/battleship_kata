using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.BoardRules;

namespace BattelshipKata.Domain.BoardManagement
{
    public class BoardService
    {
        public IRule InBoardRuleFactory(Board board, Ship ship)
        {
            return new InBoardRule(board, ship);
        }
        public IRule SpaceShipRuleFactory(Board board, IEnumerable<Ship> ships)
        {
            return new SpacedShipsRule(board, ships);
        }
        public bool IsInBoard(IEnumerable<IRule> rules)
        {
            return rules.Where(r=>!r.IsMatch()).Count() == 0;
        }
    }
}