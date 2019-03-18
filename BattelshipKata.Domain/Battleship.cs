using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain.BoardManagement;

namespace BattelshipKata.Domain
{
    public class Battelship
    {
        
        public int PlayerCount { get; set; }
       
        public Board Board { get; set; }
        public int BoardSize { get=> Board.Size; }
        public Battelship(int size = 10, int shipCount = 11, int playerCount = 2)
        {
            this.Board = new Board(size,shipCount);
            this.PlayerCount = playerCount;
        }
    }
}
