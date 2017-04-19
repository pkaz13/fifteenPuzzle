using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class GameBoard
    {
        public int Columns { get; set; }

        public int Rows { get; set; }

        public int[,] Puzzles { get; set; }

        public GameBoard(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.Puzzles = new int[rows, columns];
        }
    }
}
