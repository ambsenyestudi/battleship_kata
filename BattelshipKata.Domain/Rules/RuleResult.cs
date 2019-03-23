using System;

namespace BattelshipKata.Domain.Rules
{
    public class RuleResult : IRuleResult
    {
        private Action actionToBeExecuted;

        public RuleResult()
        {

        }

        public RuleResult(Action actionToBeExecuted)
        {
            this.actionToBeExecuted = actionToBeExecuted;
        }

        public bool IsSuccess { get => actionToBeExecuted != null; }

        public void Execute()
        {
            actionToBeExecuted?.Invoke();
        }
    }
}