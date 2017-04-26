using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class BFS 
    {
        public GameBoard InitialBoard { get; set; }

        //private PossibleMoves possibleMoves;

        public BFS(string filePath)
        {
            InitialBoard = new GameBoard(filePath);
        }

        public Solution Search()
        {
            int numberofIteretions = 0;
            Solution solution = new Solution();
            Queue<GameBoard> queue = new Queue<GameBoard>();
            queue.Enqueue(InitialBoard);
            while (queue.Count > 0)
            {
                GameBoard currentBoard = queue.Dequeue();
                solution.board = currentBoard;
                if (currentBoard.IsPuzzleSolved())
                {
                    return solution;
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LRUD.ToString())
                {
                    currentBoard.Adjacents.Add(currentBoard.CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateUp(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LRD.ToString())
                {
                    currentBoard.Adjacents.Add(currentBoard.CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LUD.ToString())
                {
                    currentBoard.Adjacents.Add(currentBoard.CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateUp(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LRU.ToString())
                {
                    currentBoard.Adjacents.Add(currentBoard.CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateUp(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.RUD.ToString())
                {
                    currentBoard.Adjacents.Add(currentBoard.CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateUp(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.RD.ToString())
                {
                    currentBoard.Adjacents.Add(currentBoard.CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LD.ToString())
                {
                    currentBoard.Adjacents.Add(currentBoard.CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LU.ToString())
                {
                    currentBoard.Adjacents.Add(currentBoard.CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateUp(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.RU.ToString())
                {
                    currentBoard.Adjacents.Add(currentBoard.CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(currentBoard.CreateStateUp(currentBoard));
                }
                foreach (GameBoard board in currentBoard.Adjacents)
                {
                    queue.Enqueue(board);
                }
                numberofIteretions++;
                Console.WriteLine(numberofIteretions);
            }
            return null;
        }

        
    }
}
