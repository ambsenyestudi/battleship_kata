using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Rules.ShotRules;
using BattelshipKata.Test.Helpers;
using Moq;
using Xunit;

namespace BattelshipKata.Test.Rules.ShotRules
{
    public class UpdateSquareToMissShould : IClassFixture<UpdateSquareToMissFixture>
    {
        private readonly UpdateSquareToMissFixture fixture;

        public UpdateSquareToMissShould(UpdateSquareToMissFixture fixture)
        {
            this.fixture = fixture;
        }
        
        
        [Fact]
        public void Discover_miss_on_empty_square()
        {
            //Given 2 x 2 Board
            var board = fixture.Init2x2SubAtBottom();
            var missPos = Position.Zero;
            var rule = new UpdateSquareToMissRule(board.BoardSquares, board.Fleet, missPos, board.Size, 
            ()=>{
                fixture.BoardUpdateServiceMock.Object.UpdateMissShot(board, missPos);
            });
            //When
            var evaluator = rule.Eval();
            if (evaluator.IsSuccess)
            {
                evaluator.Execute();
            }
            //Then
            fixture.BoardUpdateServiceMock.Verify(moq => 
                moq.UpdateMissShot(It.IsAny<Board>(), It.IsAny<Position>()), 
                Times.Once);
            Assert.True(evaluator.IsSuccess);
        }
    }
}