using System;
using Xunit;
using BattelshipKata.Domain;
using System.Collections.Generic;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Rules.BoardRules;
using System.Linq;
using BattelshipKata.Test.Fixtures;

namespace BattelshipKata.Test
{
    public class BoardServiceShould:IClassFixture<BoardServiceFixture>
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
            fixture.InitSizedBoard(1,ships);
            
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
            fixture.InitSizedBoard(4,ships);
            
            var result = fixture.Sut.IsInBoard(fixture.Rules);
            Assert.False(result);
        }
    }
}
