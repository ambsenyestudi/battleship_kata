
namespace BattelshipKata.Domain.BoardManagement
{
    public interface IBoardUpdateService
    {
        void UpdateMissShot(Board board, Position shotPosition);
        void UpdateFleetAndBoardHits(Board board, Position shotPosition);
    }
}