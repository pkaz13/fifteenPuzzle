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
            Solution solution = new Solution();

            List<GameBoard> open = new List<GameBoard>();
            List<GameBoard> closed = new List<GameBoard>();

            open.Add(initialGameBoard);
            if (heuristic == "hamm")
                initialGameBoard.HammingDistance();
            if (heuristic == "manh")
                initialGameBoard.ManhattanDistance();

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
                    return solution;
                }
                   
                currentBoard.CreatePossibleStates();

                foreach (GameBoard successorBoard in currentBoard.Adjacents)
                {
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

            return solution;

        }
        //public GameBoardHeuristic Search(string filePath)
        //{
        //    GameBoardHeuristic initialBoard = new GameBoardHeuristic(filePath);
        //    SimplePriorityQueue<GameBoardHeuristic> pq = new SimplePriorityQueue<GameBoardHeuristic>();
        //    List<GameBoardHeuristic> closed = new List<GameBoardHeuristic>();

        //    pq.Enqueue(initialBoard, initialBoard.F);

        //    while (pq.Count > 0)
        //    {
        //        GameBoardHeuristic currentBoard = pq.Dequeue();

        //        if (currentBoard.IsPuzzleSolved())
        //            return currentBoard;

        //        for (int i = 0; i < 4; i++)
        //        {
        //            GameBoardHeuristic moved = currentBoard.Copy(filePath);
        //            if (!moved.MoveCountingPathCost(i))
        //                continue;
        //            if (!closed.Contains(moved))
        //            {
        //                closed.Add(moved);
        //                pq.Enqueue(moved, moved.F);
        //            }
        //        }
        //    }
        //    return null;
        //}

        //public Solution Search()
        //{
        //    Solution solution = new Solution();

        //    List<GameBoard> open = new List<GameBoard>();
        //    List<GameBoard> closed = new List<GameBoard>();

        //    open.Add(initialBoard);

        //    while (open.Count > 0)
        //    {
        //        int minF = open.Select(x => x.F).Min();
        //        GameBoard currentBoard = open.FirstOrDefault(x => x.F == minF);

        //        solution.board = currentBoard;

        //        if (currentBoard.IsPuzzleSolved())
        //            return solution;

        //        open.Remove(currentBoard);
        //        closed.Add(currentBoard);

        //        foreach (GameBoard board in currentBoard.Adjacents)
        //        {
        //            if (!closed.Contains(board))
        //            {
        //                board.F = board.G + board.HammingDistance();
        //                if (!open.Contains(board))
        //                    open.Add(board);
        //                else
        //                {

        //                }
        //            }
        //        }
        //    }
        //    return new Solution();
        //}

        //public Solution Search()
        //{
        //    Solution solution = new Solution();

        //    List<GameBoard> open = new List<GameBoard>();
        //    List<GameBoard> closed = new List<GameBoard>();

        //    open.Add(initialBoard);

        //    while (open.Count > 0)
        //    {
        //        int minF = open.Select(x => x.F).Min();
        //        GameBoard currentBoard = open.FirstOrDefault(x => x.F == minF);

        //        solution.board = currentBoard;

        //        if (currentBoard.IsPuzzleSolved())
        //        {
        //            return solution;
        //        }

        //        currentBoard.CreatePossibleStates();

        //        foreach (GameBoard board in currentBoard.Adjacents)
        //        {
        //            int oFound = open.IndexOf(board);

        //            if (oFound > 0)
        //            {
        //                GameBoard existingBoard = open.ElementAt(oFound);
        //                if (existingBoard.G <= currentBoard.G)
        //                    continue;
        //            }

        //            int cFound = closed.IndexOf(board);

        //            if (cFound > 0)
        //            {
        //                GameBoard existingBoard = open.ElementAt(cFound);
        //                if (existingBoard.G <= currentBoard.G)
        //                    continue;
        //            }

        //            if (oFound != -1)
        //                open.RemoveAt(oFound);
        //            if (cFound != -1)
        //                closed.RemoveAt(cFound);

        //            board.F = board.G + board.HammingDistance();

        //            open.Add(board);
        //        }
        //        closed.Add(currentBoard);
        //    }


        //    return new Solution();
        //}
    }
}
