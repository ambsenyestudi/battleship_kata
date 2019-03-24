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
        public List<IMatchRule> Rules { get; set; }
        public BoardServiceFixture()
        {
            Sut = new BoardService();
        }
        public void InitSizedBoard(int size, IList<Ship> ships)
        {
            Board = new Board(size, ships);
            Rules = new List<IMatchRule>
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
                //xxxx0xxx0x
                new Ship(ShipType.Battelship)
                {
                    Position = Position.Zero
                },
                //C1
                new Ship(ShipType.Cruiser)
                {
                    Position = new Position{ X=5, Y=0 }
                },
                //S1
                new Ship(ShipType.Submarine)
                {
                    Position = new Position{ X=9, Y=0 }
                },
                //0000000000
                //xxx0xx00x0
                //C2
                new Ship(ShipType.Cruiser)
                {
                    Position =  new Position{ X=0, Y=2 }
                },
                //D1
                new Ship(ShipType.Destroyer)
                {
                    Position = new Position{ X=4, Y=2 }
                },
                new Ship(ShipType.Submarine)
                {
                    Position = new Position{ X=8, Y=2 }
                },
                //0000000000
                //xx0xx0x0x0
                //D2
                new Ship(ShipType.Destroyer)
                {
                    Position = new Position{ X=0, Y=4 }
                },
                //D3
                new Ship(ShipType.Destroyer)
                {
                    Position = new Position{ X=3, Y=4 }
                },
                //S2
                new Ship(ShipType.Submarine)
                {
                    Position = new Position{ X=6, Y=4 }
                },
                //S3
                new Ship(ShipType.Submarine)
                {
                    Position = new Position{ X=8, Y=4 }
                },
                //0000000000
                //x0x0000000
                //S4
                new Ship(ShipType.Submarine)
                {
                    Position = new Position{ X=0, Y=6 }
                }
                ,
                //S5
                new Ship(ShipType.Submarine)
                {
                    Position = new Position{ X=2, Y=6 }
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