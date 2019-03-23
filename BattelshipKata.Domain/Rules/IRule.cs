namespace BattelshipKata.Domain.Rules
{
    public interface IRule
    {
        IRuleResult Eval();
    }
}