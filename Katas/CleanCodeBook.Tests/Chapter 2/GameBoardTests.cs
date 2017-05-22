using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CleanCodeBook.Tests.Chapter_2.Iteration_1
{
    public class SomeStuff
    {
        List<int[]> theList = new List<int[]>
            {
                new int[] {1,2,3} ,
                new int[] {4,2,3}
            };

        public List<int[]> GetThem()
        {
            List<int[]> list1 = new List<int[]>();
            foreach (int[] x in theList)
            {
                if (x[0] == 4)
                {
                    list1.Add(x);
                }
            }
            return list1;
        }
    }

    public class SomeStuffTests
    {
        [Fact]
        public void Launch()
        {
            var someStuff = new SomeStuff();
            var them = someStuff.GetThem();
        }
    }
}


namespace CleanCodeBook.Tests.Chapter_2.Iteration_2
{
    public class Game
    {
        const int Flagged_Cell = 4;
        const int Status_Value = 0;

        List<int[]> Board = new List<int[]>
            {
                new int[] {1,2,3} ,
                new int[] {4,2,3}
            };

        public List<int[]> GetFlaggedCells()
        {
            List<int[]> flaggedCells = new List<int[]>();
            foreach (int[] cell in Board)
            {
                if (cell[Status_Value] == Flagged_Cell)
                {
                    flaggedCells.Add(cell);
                }
            }
            return flaggedCells;
        }
    }

    public class GameTests
    {
        [Fact]
        public void Launch()
        {
            var someStuff = new Game();
            var them = someStuff.GetFlaggedCells();
        }
    }
}


namespace CleanCodeBook.Tests.Chapter_2.Iteration_3
{
    public class Cell
    {
        public bool IsFlagged { get; set; }
    }

    public class Game
    {    
        List<Cell> Board = new List<Cell>
            {
                new Cell { },
                new Cell {IsFlagged = true}
            };

        public List<Cell> GetFlaggedCells()
        {
            List<Cell> flaggedCells = new List<Cell>();
            foreach (Cell cell in Board)
            {
                if (cell.IsFlagged)
                {
                    flaggedCells.Add(cell);
                }
            }
            return flaggedCells;
        }
    }

    public class GameTests
    {
        [Fact]
        public void Launch()
        {
            var someStuff = new Game();
            var them = someStuff.GetFlaggedCells();
        }
    }
}


namespace CleanCodeBook.Tests.Chapter_2.Iteration_4
{
    public class Cell
    {
        public bool IsFlagged { get; set; }
    }

    public class Game
    {    
        List<Cell> Board = new List<Cell>
            {
                new Cell { },
                new Cell {IsFlagged = true}
            };

        public List<Cell> GetFlaggedCells()
        {
            return Board
                .Where(c => c.IsFlagged)
                .ToList();
        }
    }

    public class GameTests
    {
        [Fact]
        public void Launch()
        {
            var someStuff = new Game();
            var them = someStuff.GetFlaggedCells();
        }
    }
}
