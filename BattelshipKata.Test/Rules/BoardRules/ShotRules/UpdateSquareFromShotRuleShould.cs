using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Rules.ShotRules;
using BattelshipKata.Domain.Ships;
using BattelshipKata.Test.Helpers;
using Xunit;

namespace BattelshipKata.Test.Rules.BoardRules.ShotRules
{
    public class UpdateSquareFromShotRuleShould
    {


        [Fact]
        public void Hit_successfully_on_occupied_square()
        {
            //Given 2 x 1 Board
            var size = 2;
            var squares = TestFactory.GetSquares(size);
            var ships = TestFactory.GetSingleSumbarineAsShips();
            var hitPos = Position.Zero;
            var board = new Board{BoardSquares = squares.ToList(), Fleet=ships};
            var rule = new ShotHitRule(board, hitPos,
            ()=>{var s ="Todo update action";});
            //When
            var evaluator = rule.Eval();
            if (evaluator.IsSuccess)
            {
                evaluator.Execute();
            }
            //Then
            Assert.Equal(SquareGameState.Hit, squares.First().GameState);
        }
        [Fact]
        public void Not_hit_successfully_on_occupied_square()
        {
            //Given 2 x 2 Board
            var width = 2;
            var height = 2;
            var squares = TestFactory.GetSquares(width * height);
            var subPos = new Position { X = 0, Y = 1 };
            var missPos = Position.Zero;
            var ships = TestFactory.GetSingleSumbarineAsShips(subPos);
            var board = new Board{BoardSquares = squares.ToList(), Fleet=ships};
            var rule = new ShotHitRule(board, missPos,
            ()=>{var s ="Todo update action";});
            //When
            var IsSuccess = rule.Eval().IsSuccess;
            //Then
            Assert.False(IsSuccess);
        }
        [Fact]
        public void Not_discover_on_square_hit_rule_fail()
        {
            //Given 2 x 2 Board
            var width = 2;
            var height = 2;
            var squares = TestFactory.GetSquares(width * height);
            var subPos = new Position { X = 0, Y = 1 };
            var missPos = Position.Zero;
            var ships = TestFactory.GetSingleSumbarineAsShips(subPos);
            var board = new Board{BoardSquares = squares.ToList(), Fleet=ships};
            var rule = new ShotHitRule(board, missPos,
            ()=>{var s ="Todo update action";});
            //When
            var evaluator = rule.Eval();
            var IsSuccess = evaluator.IsSuccess;
            //this is wrong on purpuse to test extreme case
            evaluator.Execute();
            var isCovered = squares.First().GameState == SquareGameState.Covered;
            //Then
            Assert.True(isCovered);
        }
        [Fact]
        public void Discover_miss_on_empty_square()
        {
            //Given 2 x 2 Board
            var width = 2;
            var height = 2;
            var square = TestFactory.GetSquares(width * height);
            var subPos = new Position { X = 0, Y = 1 };
            var missPos = Position.Zero;
            var ships = TestFactory.GetSingleSumbarineAsShips(subPos);
            var rule = new UpdateSquareToMissRule(square, ships, missPos, width, 
            ()=>{var s ="Todo update action";});
            //When
            var evaluator = rule.Eval();
            if (evaluator.IsSuccess)
            {
                evaluator.Execute();
            }
            var isCovered = square.First().GameState == SquareGameState.Miss;
            //Then
            Assert.True(isCovered);
        }
    }
}
