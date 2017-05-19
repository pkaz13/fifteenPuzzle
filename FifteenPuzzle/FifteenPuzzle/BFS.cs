using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class BFS
    {
        private GameBoard initialBoard;

        public BFS(string filePath)
        {
            initialBoard = new GameBoard(filePath);
        }

        public Solution Search(string moves)
        {
            int statesVisited = 0;
            int depthOfRecursion = 0;
            char[] movesFromParameter = moves.ToCharArray();
            char[] possibleMovesFromBoard;
                 
            Solution solution = new Solution();
            Queue<GameBoard> queue = new Queue<GameBoard>();
            queue.Enqueue(initialBoard);

            while (queue.Count > 0)
            {
                GameBoard currentBoard = queue.Dequeue();
                statesVisited++;
                depthOfRecursion = currentBoard.GetDepthOfState();
                possibleMovesFromBoard = currentBoard.PossibleMoves.ToCharArray();

                if (currentBoard.IsPuzzleSolved())
                {
                    solution.board = currentBoard;
                    solution.NumberOfMoves = currentBoard.MovesMade.Length;
                    solution.MovesMade = currentBoard.MovesMade;
                    solution.StatesVisited = statesVisited;
                    solution.MaxDepthOfRecursion = depthOfRecursion;
                    return solution;
                }
                
                for (int i = 0; i < movesFromParameter.Length; i++)
                {
                    if (currentBoard.CheckIfMoveIsPossible(movesFromParameter[i], possibleMovesFromBoard))
                    {
                        currentBoard.Adjacents.Add(currentBoard.CreateStateDependingOnChar(movesFromParameter[i]));
                    }
                }
                foreach (GameBoard board in currentBoard.Adjacents)
                {
                    queue.Enqueue(board);
                }
            }
            solution.NumberOfMoves = -1;
            solution.MovesMade = String.Empty;
            solution.StatesVisited = statesVisited;
            solution.MaxDepthOfRecursion = depthOfRecursion;

            return solution;
        }
    }
}
