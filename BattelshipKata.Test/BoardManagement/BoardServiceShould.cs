using System;
using Xunit;
using BattelshipKata.Domain;
using System.Collections.Generic;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.BoardRules;
using System.Linq;
using BattelshipKata.Test.BoardManagement.Fixtures;

namespace BattelshipKata.Test.BoardManagement
{
    public class BoardServiceShould : IClassFixture<BoardServiceFixture>
    {
        private readonly BoardServiceFixture fixture;

        public BoardServiceShould(BoardServiceFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        public void Not_be_valid_when_battleship_out_of_board()
        {
            var ships = new List<Ship>
            {
                new Ship(ShipType.Battelship)
            };
            fixture.InitSizedBoard(1, ships);

            var result = fixture.Sut.IsInBoard(fixture.Rules);
            Assert.False(result);
        }
        [Fact]
        public void Validate_battleship_when_fits()
        {
            var ships = new List<Ship>
            {
                new Ship(ShipType.Battelship)
            };
            fixture.InitSizedBoard(4, ships);

            var result = fixture.Sut.IsInBoard(fixture.Rules);
            Assert.True(result);
        }
        [Fact]
        public void Not_validate_battleship_when_too_far_left()
        {
            var ships = new List<Ship>
            {
                new Ship(ShipType.Battelship)
                {
                    Position = new Position { X =-1, Y = 0}
                }
            };
            fixture.InitSizedBoard(4, ships);

            var result = fixture.Sut.IsInBoard(fixture.Rules);
            Assert.False(result);
        }
        [Fact]
        public void Not_validate_battleship_when_too_far_up()
        {
            var ships = new List<Ship>
            {
                new Ship(ShipType.Battelship)
                {
                    Position = new Position { X = 0, Y = -1}
                }
            };
            fixture.InitSizedBoard(4, ships);

            var result = fixture.Sut.IsInBoard(fixture.Rules);
            Assert.False(result);
        }
        [Fact]
        public void Validate_when_battleship_vertical_top_right()
        {
            var ships = new List<Ship>
            {
                new Ship(ShipType.Battelship)
                {
                    Position = new Position { X = 3, Y = 0},
                    ShipOrientation = ShipOrientation.Vertical
                }
            };
            fixture.InitSizedBoard(4, ships);

            var result = fixture.Sut.IsInBoard(fixture.Rules);
            Assert.True(result);
        }
        [Fact]
        public void Validate_when_battleship_horizontal_bottom_left()
        {
            var ships = new List<Ship>
            {
                new Ship(ShipType.Battelship)
                {
                    Position = new Position { X = 0, Y = 3 }
                }
            };
            fixture.InitSizedBoard(4, ships);

            var result = fixture.Sut.IsInBoard(fixture.Rules);
            Assert.True(result);
        }
        [Fact]
        public void Validate_fleat_when_in_bounds()
        {
            fixture.InitRegularCorrectBoard();

            var result = fixture.Sut.IsInBoard(fixture.Rules);
            Assert.True(result);
        }
        //xxxx0xxx0x
        //0000000000
        //xxx0xx00x0
        //0000000000
        //xx0xx0x0x0
        //0000000000
        //x0x0000000
        [Fact]
        public void Validate_fleat_when_in_right_board_space()
        {
            fixture.InitRegularWellSpacedBoard();

            var result = fixture.Sut.IsInBoard(fixture.Rules);
            Assert.True(result);
        }
    }
}
