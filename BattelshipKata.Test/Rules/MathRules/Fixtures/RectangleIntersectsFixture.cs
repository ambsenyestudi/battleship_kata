using System;
using BattelshipKata.Domain;
using BattelshipKata.Domain.Rules.MathRules;

namespace BattelshipKata.Test.Rules.ShotRules
{
    public class RectangleIntersectsFixture : IDisposable
    {
        public RectangleIntersectsRule RuleFactory(Rectangle firstRect, Rectangle secondRect)
        {
            var rule = new RectangleIntersectsRule(firstRect, secondRect, null) ;
            return rule;
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}