using System;

namespace BattelshipKata.Domain.Rules
{
    internal class AllwaysSuccessRule : IRule
    {
        private Action otherwiseAction;

        public AllwaysSuccessRule(Action otherwiseAction)
        {
            this.otherwiseAction = otherwiseAction;
        }

        public IRuleResult Eval()
        {
            return new RuleResult(otherwiseAction){IsSuccess = true};
        }
    }
}