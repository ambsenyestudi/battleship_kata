using System;
using System.Collections.Generic;
using System.Linq;

namespace BattelshipKata.Domain.Rules
{
    public class RulesEvaluator
    {
        private readonly IList<RulesChain> rules;

        public RulesEvaluator()
        {
            this.rules = new List<RulesChain>();
        }

        public RulesChain Eval(IRule rule)
        {
            var rulesChain = new RulesChain(rule);
            this.rules.Add(rulesChain);
            return rulesChain;
        }

        public void OtherwiseEval(IRule alternativeRule)
        {
            if (this.rules.Count == 0)
            {
                throw new ArgumentException("You cannot add ElseIf clause without If!");
            }
            this.rules.Last().ElseRules.Add(new RulesChain(alternativeRule));
        }
        
        public void OtherwiseDo(Action otherwiseAction)
        {
            if (this.rules.Count == 0)
            {
                throw new ArgumentException("You cannot add Else clause without If!");
            }
            this.rules.Last().ElseRules.Add(new RulesChain(new AllwaysSuccessRule(otherwiseAction), true));
        }
        
        public void EvaluateRulesChains()
        {
            //var isElseRules = rules.Where(r=>r.ElseRules !=null && r.ElseRules.Any()).Count() > 0;
            this.Evaluate(this.rules, false);
        }

        private void Evaluate(IList<RulesChain> rulesToBeEvaluated, bool isAlternativeChain = false)
        {
            foreach (var currentRuleChain in rulesToBeEvaluated)
            {
                var currentRulesChainResult = currentRuleChain.Rule.Eval();
                if (currentRulesChainResult.IsSuccess)
                {
                    currentRulesChainResult.Execute();
                    if (isAlternativeChain)
                    {
                        break;
                    }
                }
                else
                {
                    this.Evaluate(currentRuleChain.ElseRules, true);
                }
            }
        }

    }
}