using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class BFS : IAlgorithm
    {
        public GameBoard InitialBoard { get; set; }

        private PossibleMoves possibleMoves;

        public BFS(string filePath)
        {
            InitialBoard = new GameBoard(filePath);
        }

        public void Search() //include checking if solution is found
        {
            Queue<GameBoard> queue = new Queue<GameBoard>();
            queue.Enqueue(InitialBoard);
            while (queue.Count > 0)
            {
                GameBoard currentBoard = queue.Dequeue();
                if (currentBoard.PossibleMoves == PossibleMoves.LRUD.ToString())
                {
                    currentBoard.Adjacents.Add(currentBoard.CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateUp(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateDown(currentBoard));
                }
                //complete all if's
                foreach (GameBoard board in currentBoard.Adjacents)
                {
                    queue.Enqueue(board);
                }
            }
        }
    }
}
