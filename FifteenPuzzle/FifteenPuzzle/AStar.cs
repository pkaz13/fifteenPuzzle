using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace FifteenPuzzle
{
    public class AStar
    {

        public GameBoard initialGameBoard { get; set; }

        public AStar(string filePath)
        {
            initialGameBoard = new GameBoard(filePath);
        }

        public Solution Search(string heuristic)
        {
            int statesVisited = 0;
            Solution solution = new Solution();

            List<GameBoard> open = new List<GameBoard>();
            List<GameBoard> closed = new List<GameBoard>();

            open.Add(initialGameBoard);
            if (heuristic == "hamm")
                initialGameBoard.HammingDistance();
            if (heuristic == "manh")
                initialGameBoard.ManhattanDistance();

            statesVisited++;

            while (open.Count > 0)
            {
                int minF = open.Min(x => x.F);
                GameBoard currentBoard = open.Find(x => x.F == minF);
                open.Remove(currentBoard);

                if (currentBoard.IsPuzzleSolved())
                {
                    solution.board = currentBoard;
                    solution.MovesMade = currentBoard.MovesMade;
                    solution.NumberOfMoves = currentBoard.MovesMade.Length;
                    solution.StatesVisited = statesVisited;
                    return solution;
                }
                   
                currentBoard.CreatePossibleStates();

                foreach (GameBoard successorBoard in currentBoard.Adjacents)
                {
                    statesVisited++;
                    if (heuristic == "hamm")
                    {
                        successorBoard.G++;
                        successorBoard.HammingDistance();
                        successorBoard.CountF();
                    }
                    if (heuristic == "manh")
                    {
                        successorBoard.G++;
                        successorBoard.ManhattanDistance();
                        successorBoard.CountF();
                    }

                    if (open.Contains(successorBoard))
                        continue;
                    if (closed.Contains(successorBoard))
                        continue;
                    else
                        open.Add(successorBoard);
                }
                closed.Add(currentBoard);
            }
            solution.NumberOfMoves = -1;
            solution.MovesMade = String.Empty;
            solution.StatesVisited = statesVisited;

            return solution;
        }

        private float TimeCount(float start, float end)
        {
            return end - start;
        }
    }
}
