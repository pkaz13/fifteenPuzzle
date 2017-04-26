using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class DFS
    {
        public GameBoard InitialBoard { get; set; }

        public DFS(string filepath)
        {
            InitialBoard = new GameBoard(filepath);
        }

        public void Search(string moves)
        {
            Stack<GameBoard> stack = new Stack<GameBoard>();
            stack.Push(InitialBoard);

            while (stack.Count > 0)
            {

            }
        }
        
    }
}
