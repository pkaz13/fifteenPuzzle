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

        public BFS(string filePath)
        {
            InitialBoard = new GameBoard(filePath);
        }

        public Solution Search(string moves)
        {
            char[] movesFromParameter = moves.ToCharArray();
            char[] possibleMovesFromBoard;
                 
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
                possibleMovesFromBoard = currentBoard.PossibleMoves.ToCharArray();

                for (int i = 0; i < movesFromParameter.Length; i++)
                {
                    if (currentBoard.CheckIfMoveIsPossible(movesFromParameter[i], possibleMovesFromBoard))
                    {
                        currentBoard.Adjacents.Add(currentBoard.CreateStateDependingOnChar(currentBoard, movesFromParameter[i]));
                    }
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
