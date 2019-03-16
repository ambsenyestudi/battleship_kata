using System;
using System.Collections.Generic;
using System.Linq;
using BattelshipKata.Domain;
using BattelshipKata.Domain.Rules;

namespace BattelshipKata.Test.Fixtures
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
        public void InitSizedBoard(int size, IEnumerable<Ship> ships)
        {
            Board = new Board(size, ships);
            Rules = new List<IRule>
            {
                Sut.InBoardRuleFactory(Board, ships.First())
            };
        }
        public void InitRegularWellSpacedBoard()
        {
            var ships = WellSpacedAcrossBoardShipsFactory();
            InitRegularCorrectBoard(ships);
            Rules.Add(Sut.SpaceShipRuleFactory(Board, ships));
        }
        public void InitRegularCorrectBoard(IEnumerable<Ship>ships = null)
        {
            if(ships == null)
            {
                ships = WellSpacedAcrossBoardShipsFactory();
            }
            InitSizedBoard(BoardServiceFixture.DEFAULT_SIZE, ships);
        }
        public IEnumerable<Ship> WellSpacedAcrossBoardShipsFactory()
        {
            var ships = new List<Ship>
            {
                //xxxx0xxx0x
                new Ship(ShipType.Battelship)
                {
                    Position = (0, 0)
                },
                //C1
                new Ship(ShipType.Cruiser)
                {
                    Position = (5, 0)
                },
                //S1
                new Ship(ShipType.Submarine)
                {
                    Position = (9, 0)
                },
                //0000000000
                //xxx0xx00x0
                //C2
                new Ship(ShipType.Cruiser)
                {
                    Position = (0, 2)
                },
                //D1
                new Ship(ShipType.Destroyer)
                {
                    Position = (4, 2)
                },
                new Ship(ShipType.Submarine)
                {
                    Position = (8, 2)
                },
                //0000000000
                //xx0xx0x0x0
                //D2
                new Ship(ShipType.Destroyer)
                {
                    Position = (0, 4)
                },
                //D3
                new Ship(ShipType.Destroyer)
                {
                    Position = (3, 4)
                },
                //S2
                new Ship(ShipType.Submarine)
                {
                    Position = (6, 4)
                },
                //S3
                new Ship(ShipType.Submarine)
                {
                    Position = (8, 4)
                },
                //0000000000
                //x0x0000000
                //S4
                new Ship(ShipType.Submarine)
                {
                    Position = (0, 6)
                }
                ,
                //S5
                new Ship(ShipType.Submarine)
                {
                    Position = (2, 6)
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