namespace BattelshipKata.Domain.Rules
{
    public interface IRuleResult
    {
        bool IsSuccess { get; }
        void Execute();
    }
}