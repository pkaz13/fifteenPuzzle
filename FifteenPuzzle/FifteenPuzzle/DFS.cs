using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class DFS
    {
        private GameBoard initialBoard;

        public int MaxDepthOfRecursion { get; set; }

        private const int maxDepthOfRecursion = 20;

        public DFS(string filepath)
        {
            initialBoard = new GameBoard(filepath);
        }

        public Solution Search(string moves)
        {
            char[] movesFromParameter = moves.ToCharArray();
            char[] possibleMovesFromBoard;
            int depthOfRecursion = 0;
            int statesVisited = 0;

            Solution solution = new Solution();
            Stack<GameBoard> stack = new Stack<GameBoard>();
            stack.Push(initialBoard);

            while (stack.Count > 0)
            {
                GameBoard currentBoard = stack.Pop();
                statesVisited++;

                possibleMovesFromBoard = currentBoard.PossibleMoves.ToCharArray();
                depthOfRecursion = currentBoard.GetDepthOfState();

                if (currentBoard.Depth > maxDepthOfRecursion)
                {
                    MaxDepthOfRecursion = depthOfRecursion; //maximal depth of recursion
                }

                if (currentBoard.IsPuzzleSolved())
                {
                    solution.board = currentBoard;
                    solution.NumberOfMoves = currentBoard.MovesMade.Length;
                    solution.MovesMade = currentBoard.MovesMade;
                    solution.MaxDepthOfRecursion = MaxDepthOfRecursion;
                    solution.StatesVisited = statesVisited;
                    return solution;
                }

                if (depthOfRecursion <= maxDepthOfRecursion)
                {
                    for (int i = 0; i < movesFromParameter.Length; i++)
                    {
                        if (currentBoard.CheckIfMoveIsPossible(movesFromParameter[i], possibleMovesFromBoard))
                        {
                            currentBoard.Adjacents.Add(currentBoard.CreateStateDependingOnChar(movesFromParameter[i]));
                        }
                    }
                    foreach (GameBoard board in currentBoard.Adjacents)
                    {
                        stack.Push(board);
                    }
                }
            }
            solution.NumberOfMoves = -1;
            solution.MovesMade = String.Empty;
            solution.StatesVisited = statesVisited;
            return solution;
        }


    }
}
