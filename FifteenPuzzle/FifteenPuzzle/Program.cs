﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            Stopwatch watch = null;
            long elapsedMs = 0;

            string filePath = @"../../../" + args[2];

            switch (args[0])
            {
                case "bfs":
                    bfs = new BFS(filePath);
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    solution = bfs.Search(args[1]);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    FileHelper.SaveSolution(solution.NumberOfMoves, solution.MovesMade, args[3]);
                    FileHelper.SaveStats(solution.NumberOfMoves, solution.StatesVisited, solution.MaxDepthOfRecursion, elapsedMs, args[4]);
                    break;
                case "dfs":
                    dfs = new DFS(filePath);
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    solution = dfs.Search(args[1]);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    FileHelper.SaveSolution(solution.NumberOfMoves, solution.MovesMade, args[3]);
                    FileHelper.SaveStats(solution.NumberOfMoves, solution.StatesVisited, solution.MaxDepthOfRecursion, elapsedMs, args[4]);
                    break;
                case "astr":
                    aStar = new AStar(filePath);
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    solution = aStar.Search(args[1]);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    FileHelper.SaveSolution(solution.NumberOfMoves, solution.MovesMade, args[3]);
                    FileHelper.SaveStats(solution.NumberOfMoves, solution.StatesVisited, solution.MaxDepthOfRecursion, elapsedMs, args[4]);
                    break;
                default:
                    break;
            }
        }
    }
}
