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
            string filePath = @"../../../4x4_03_00007.txt";
            string solvedfilePath = @"../../../solved.txt";

            GameBoard board = new GameBoard(filePath);

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

            Console.WriteLine("--------------------------------");

            DFS dfs = new DFS(filePath);
            double startDFS = Environment.TickCount;
            Solution solutionDFS = dfs.Search("RUDL");
            double stopDFS = Environment.TickCount - startDFS;
            FileHelper.SaveSolution(solutionDFS.NumberOfMoves, solutionDFS.MovesMade);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(string.Format("{0} ", solutionDFS.board.Puzzles[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.WriteLine(stopDFS);
            //Console.WriteLine(solutionDFS.MaxDepthOfRecursion);


            Console.ReadKey();

        }
    }
}
