using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class Vertex
    {
        public bool IsVisited { get; set; }
        public GameBoard Board { get; set; }

        public Vertex(bool isVisited, GameBoard board)
        {
            this.IsVisited = isVisited;
            this.Board = board;
        }
    }
}
