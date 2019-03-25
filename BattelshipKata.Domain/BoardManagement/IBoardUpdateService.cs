
namespace BattelshipKata.Domain.BoardManagement
{
    public interface IBoardUpdateService
    {
        void UpdateMissShot(Board board, Position shotPosition);
        void UpdateFleetAndBoardHits(Board board, Position shotPosition);
        void ResetOutcome(Board board);
        void UpdateAlreadyHitOutcome(Board board);
        void UpdateOutcome(Board board, ShotActionOutcome outcome);
    }
}