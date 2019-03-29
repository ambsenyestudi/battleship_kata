using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.BoardRules;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.BoardManagement
{
    public class BoardService
    {
        public IRule SpaceShipRuleFactory(Board board, IEnumerable<Ship> ships)
        {
            return new SpacedShipsRule(board, ships, null);
        }
        public bool IsInBoard(IEnumerable<IRule> rules)
        {
            return rules.Where(r=>!r.Eval().IsSuccess).Count() == 0;
        }
    }
}