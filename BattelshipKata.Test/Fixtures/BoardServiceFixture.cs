using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.Rules;

namespace BattelshipKata.Test.Fixtures
{
    public class BoardServiceFixture : IDisposable
    {
        public BoardService Sut { get; set; }
        public Board Board { get; set; }
        public List<IRule> Rules { get; set; }
        public BoardServiceFixture()
        {
            Sut = new BoardService();
        }
        public void InitSizedBoard(int size, IEnumerable<Ship> ships)
        {
            Board = new Board(size,ships);
            Rules = new List<IRule>
            {
                Sut.InBoardRuleFactory(Board, ships.First())  
            };
        }
        public void Dispose()
        {
            Sut = null;
        }
    }
}