using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            DFS dfs = null;
            BFS bfs = null;
            AStar aStar = null;

            Solution solution = null;

            string filePath = @"../../../" + args[2];

            switch (args[0])
            {
                case "bfs":
                    bfs = new BFS(filePath);
                    solution = bfs.Search(args[1]);
                    FileHelper.SaveSolution(solution.NumberOfMoves, solution.MovesMade, args[3]);
                    FileHelper.SaveStats(solution.NumberOfMoves, 0, 0, 0, args[4]);
                    break;
                case "dfs":
                    dfs = new DFS(filePath);
                    solution = dfs.Search(args[1]);
                    FileHelper.SaveSolution(solution.NumberOfMoves, solution.MovesMade, args[3]);
                    FileHelper.SaveStats(solution.NumberOfMoves, 0, 0, 0, args[4]);
                    break;
                case "astr":
                    aStar = new AStar(filePath);
                    solution = aStar.Search(args[1]);
                    FileHelper.SaveSolution(solution.NumberOfMoves, solution.MovesMade, args[3]);
                    FileHelper.SaveStats(solution.NumberOfMoves, 0, 0, 0, args[4]);
                    break;
                default:
                    break;
            }
            //string filePath = @"../../../4x4_01_00002.txt";
            //string solvedfilePath = @"../../../solved.txt";

            //GameBoard board = new GameBoard(filePath);
            //board.CreatePossibleStates();

            //BFS bfs = new BFS(filePath);

            //int startBFS = Environment.TickCount;
            //Solution solutionBFS = bfs.Search("RUDL");
            //int stopBFS = Environment.TickCount - startBFS;
            //var timespanBFS = TimeSpan.FromMilliseconds(stopBFS);

            //FileHelper.SaveSolution(solutionBFS.NumberOfMoves, solutionBFS.MovesMade);

            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        Console.Write(string.Format("{0} ", solutionBFS.board.Puzzles[i, j]));
            //    }
            //    Console.Write(Environment.NewLine + Environment.NewLine);
            //}

            //Console.WriteLine(timespanBFS);
            //Console.WriteLine(solutionBFS.MaxDepthOfRecursion);

            //DFS dfs = new DFS(filePath);
            //double startDFS = Environment.TickCount;
            //Solution solutionDFS = dfs.Search("RUDL");
            //double stopDFS = Environment.TickCount - startDFS;
            ////FileHelper.SaveSolution(solutionDFS.NumberOfMoves, solutionDFS.MovesMade);

            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        Console.Write(string.Format("{0} ", solutionDFS.board.Puzzles[i, j]));
            //    }
            //    Console.Write(Environment.NewLine + Environment.NewLine);
            //}
            //Console.WriteLine(stopDFS);
            //Console.WriteLine(solutionDFS.MaxDepthOfRecursion);

            //AStar aStar = new AStar(filePath);
            //Solution solution = aStar.Search("manh");

            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        Console.Write(string.Format("{0} ", board.Puzzles[i, j]));
            //    }
            //    Console.Write(Environment.NewLine + Environment.NewLine);
            //}
            //Console.WriteLine();

            //{
            //    for (int i = 0; i < 4; i++)
            //    {
            //        for (int j = 0; j < 4; j++)
            //        {
            //            Console.Write(string.Format("{0} ", solution.board.Puzzles[i, j]));
            //        }
            //        Console.Write(Environment.NewLine + Environment.NewLine);
            //    }
            //}

            //Console.ReadKey();

        }
    }
}
