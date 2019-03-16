using BattelshipKata.Domain;

namespace BattelshipKata.Domain.Rules.BoardRules
{
    public interface IBoardRule
    {
        bool IsMatch(Board board);
    }
}