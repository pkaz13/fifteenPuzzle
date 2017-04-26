using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class Solution
    {
        public GameBoard board { get; set; }
        public int NumberOfMoves { get; set; }
        public string MovesMade { get; set; }

        public Solution()
        {
            NumberOfMoves = 0;
            MovesMade = "";
        }
    }
}
