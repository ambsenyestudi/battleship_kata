using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.Extensions;
using BattelshipKata.Domain.Rules.Base;
using BattelshipKata.Domain.Rules.MathRules;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Domain.Rules.ShipRules
{
    public class ShipsOverlapingBatchRule : BaseRule
    {
        private readonly List<Ship> shipList;
        private readonly Position offset;

        public ShipsOverlapingBatchRule(List<Ship> shipList, Position offset = null, Action actionToBeExecuted = null) : base(actionToBeExecuted)
        {
            this.shipList = shipList;
            if(offset != null)
            {
                offset = Position.Zero;
            }
            this.offset = offset;
        }

        public override IRuleResult Eval()
        {
            ruleResult.IsSuccess = BatchEvaluate();
            return ruleResult;
        }

        private bool BatchEvaluate()
        {
            var result = true;
            var count = 1;
            var evaluatedShips = shipList.Take(count);
            var max = shipList.Count - count;
            while (result && count < max)
            {
                var currShip = shipList[count];
                result = CurrentShipNotOverlapingAny(currShip, evaluatedShips);
                count++;
            }
            return result;
        }
        private bool CurrentShipNotOverlapingAny(Ship ship, IEnumerable<Ship> evaluatedShips)
        {
            return !ShipOverlapsOthers(ship, evaluatedShips);
        }
        private bool ShipOverlapsOthers(Ship ship, IEnumerable<Ship> evaluatedShips) =>
            evaluatedShips.Where(s => IsShipOvelpase(s, ship)).Count() > 0;

        private bool IsShipOvelpase(Ship firstShip, Ship secondShip)
        {
            var currboundingBox = ScaleBoundingBox(secondShip);
            return BuildRectangleRule(firstShip.BoundingBox, currboundingBox).Eval().IsSuccess;
        }
        private RectangleIntersectsRule BuildRectangleRule(Rectangle firsRect, Rectangle secondRect, Action action = null) =>
            new RectangleIntersectsRule(firsRect, secondRect, action);

        private Rectangle ScaleBoundingBox(Ship ship) => ScaleBoundingBox(ship.BoundingBox);
        private Rectangle ScaleBoundingBox(Rectangle boundingBox)
        {
            if (offset > Position.Zero)
            {
                boundingBox.ScaleOne();
            }
            return boundingBox;
        }
    }

}