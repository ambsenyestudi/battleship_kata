using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules.Base;
using BattelshipKata.Domain.Rules.ShipRules;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.BoardRules
{
    public class SpacedShipsRule : BaseRule
    {
        private readonly Board board;
        private readonly IEnumerable<Ship> ships;
        private readonly Position offset;

        public SpacedShipsRule(Board board, IEnumerable<Ship> ships, int widthOffset, int heightOffset, Action actionToBeExecuted) : base(actionToBeExecuted)
        {
            this.board = board;
            this.ships = ships;
            this.offset = new Position { X = widthOffset, Y = heightOffset };
        }
        public bool CompareShips()
        {
            var allShipsInBoard = AreAllShipsInBoard();
            if (allShipsInBoard)
            {
                var shipsOverlapingRule = new ShipsOverlapingBatchRule(ships.ToList(), offset);
                return shipsOverlapingRule.Eval().IsSuccess;
            }
            return allShipsInBoard;
        }

        private bool AreAllShipsInBoard()
        {
            return !AnyShipOutOfBoardBounds();
        }

        private bool AnyShipOutOfBoardBounds()
        {
            var rules = BuildBoardContiansRuleBatch(board, ships);
            var nonPassingBoardRules = rules.Where(ru => !ru.Eval().IsSuccess);
            return nonPassingBoardRules.Any();
        }

        private IEnumerable<BaseRule> BuildBoardContiansRuleBatch(Board board, IEnumerable<Ship> ships)
        {
            return ships.Select(sh => BuildBoardContiansRule(board, sh));
        }

        private RectangleContainsRule BuildBoardContiansRule(Board board, Ship ships, Action action = null) =>
            new RectangleContainsRule(board.Bounds, ships.BoundingBox, action);

        public override IRuleResult Eval()
        {

            ruleResult.IsSuccess = CompareShips();
            return ruleResult;
        }
    }
}