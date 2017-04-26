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

            BFS bfs = new BFS(filePath);

            //GameBoard solved = bfs.Search();
            Solution solution = bfs.Search("RUDL");
            //solution.ProccesResult();
            //Console.Write(solution.NumberOfMoves);
            //Console.WriteLine();
            //Console.Write(solution.MovesMade);
            //FileHelper.SaveSolution(solution.NumberOfMoves, solution.MovesMade);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(string.Format("{0} ", solution.board.Puzzles[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            //GameBoard board1 = board.CreateStateLeft(board);

            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        Console.Write(string.Format("{0} ", board1.Puzzles[i, j]));
            //    }
            //    Console.Write(Environment.NewLine + Environment.NewLine);
            //}

            //BFS bfs = new BFS();

            //if (board.IsPuzzleSolved() == true)
            //    Console.WriteLine("solved");
            //else
            //    Console.WriteLine("not solved");

            //int[] tab = bfs.CheckFreeSpacePosition(board.Puzzles);
            //for (int i = 0; i < tab.Length; i++)
            //{
            //    Console.WriteLine(tab[i]);
            //}

            //string moves = bfs.CheckPossibleMoves(board.Puzzles);
            //Console.Write(moves);
            //for (int i = 0; i < moves.Length; i++)
            //{
            //    Console.Write(moves);
            //}

            Console.ReadKey();

        }
    }
}
