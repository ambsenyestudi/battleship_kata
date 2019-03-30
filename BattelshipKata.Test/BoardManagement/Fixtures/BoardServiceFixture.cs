using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.BoardManagement;
using BattelshipKata.Domain.Rules;
using BattelshipKata.Domain.Ships;

namespace BattelshipKata.Test.BoardManagement.Fixtures
{
    public class BoardServiceFixture : IDisposable
    {
        public const int DEFAULT_SIZE = 10;
        public BoardService Sut { get; set; }
        public Board Board { get; set; }
        public List<IRule> Rules { get; set; }
        public BoardServiceFixture()
        {
            Sut = new BoardService();
        }
        public void InitSizedBoard(int size, IList<Ship> ships)
        {
            Board = new Board(size, ships);
            
            Rules = new List<IRule>
            {
                new RectangleContainsRule(Board.Bounds, ships.First().BoundingBox, null)
            };
        }
        public void InitRegularWellSpacedBoard()
        {
            var widthOffset = 1;
            var heightOffset = 1;
            var ships = WellSpacedAcrossBoardShipsFactory();
            InitRegularCorrectBoard(ships);
            Rules.Add(Sut.SpaceShipRuleFactory(Board, ships, widthOffset, heightOffset, null));
        }
        public void InitRegularCorrectBoard(IList<Ship> ships = null)
        {
            if (ships == null)
            {
                ships = WellSpacedAcrossBoardShipsFactory();
            }
            InitSizedBoard(BoardServiceFixture.DEFAULT_SIZE, ships);
        }
        public IList<Ship> WellSpacedAcrossBoardShipsFactory()
        {
            var ships = new List<Ship>
            {
                //xxxx0xx000
                new Ship(ShipType.Battelship)
                {
                    Position = Position.Zero
                },
                new Ship(ShipType.Destroyer)
                {
                    Position = new Position{ X=5, Y=0 }
                },
                //0000000000
                //xxxxx00xxx
                new Ship(ShipType.Carrier)
                {
                    Position =  new Position{ X=0, Y=2 }
                },
                //S1
                new Ship(ShipType.Submarine)
                {
                    Position = new Position{ X=7, Y=2 }
                },
                //0000000000
                //000xxx0000
                //S2
                new Ship(ShipType.Submarine)
                {
                    Position = new Position{ X=3, Y=4 }
                }
            };
            return ships;
        }
        public void Dispose()
        {
            Sut = null;
        }
    }
}