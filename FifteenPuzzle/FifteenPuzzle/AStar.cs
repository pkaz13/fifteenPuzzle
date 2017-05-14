using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class AStar
    {

        public GameBoardHeuristic Search(string filePath)
        {
            GameBoardHeuristic initialBoard = new GameBoardHeuristic(filePath);
            List<GameBoardHeuristic> open = new List<GameBoardHeuristic>();
            List<GameBoardHeuristic> closed = new List<GameBoardHeuristic>();

            open.Add(new GameBoardHeuristic(initialBoard));

            while (open.Count > 0)
            {
                int minF = open.Select(x => x.CountF()).Min();
                GameBoardHeuristic currentBoard = open.FirstOrDefault(x => x.CountF() == minF);

                if (currentBoard.IsPuzzleSolved())
                    return currentBoard;

                for (int i = 0; i < 4; i++)
                {
                    GameBoardHeuristic moved = currentBoard.Copy(filePath);
                    if (!moved.Move(i))
                        continue;
                    if (!closed.Contains(moved))
                    {
                        closed.Add(moved);
                        open.Add(moved);
                    }
                }
            }
            return null;
        }

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
