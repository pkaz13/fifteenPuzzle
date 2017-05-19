using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public static class FileHelper
    {
        public static int[,] InitBoard(string entryFilePath)
        {
            string[] lines = File.ReadAllLines(entryFilePath);
            int[] rowsAndColumns = lines[0].Split(new Char[] { ',', ' ' }).Select(int.Parse).ToArray();
            int[,] data = new int[rowsAndColumns[0], rowsAndColumns[1]];

            for (int i = 0; i < lines.Length - 1; i++)
            {
                int[] temp = lines[i + 1].Split(new Char[] { ',', ' ' }).Select(int.Parse).ToArray();
                for (int j = 0; j < temp.Length; j++)
                {
                    data[i, j] = temp[j];
                }
            }
            return data;
        }

        public static void SaveSolution(int numberOfMoves, string movesMade, string fileName)
        {
            if (File.Exists(@"../../../"+fileName))
            {
                File.Delete(@"../../../"+fileName);
            }
            File.AppendAllText(@"../../../" + fileName, numberOfMoves.ToString());
            File.AppendAllText(@"../../../" + fileName, Environment.NewLine);
            File.AppendAllText(@"../../../" + fileName, movesMade);
        }

        public static void SaveStats(int numberOfMoves, int numberOfStatesVisited, int maxDepthOfRecursion, long time, string fileName)
        {
            if (File.Exists(@"../../../" + fileName))
            {
                File.Delete(@"../../../" + fileName);
            }
            File.AppendAllText(@"../../../" + fileName, numberOfMoves.ToString());
            File.AppendAllText(@"../../../" + fileName, Environment.NewLine);
            File.AppendAllText(@"../../../" + fileName, numberOfStatesVisited.ToString());
            File.AppendAllText(@"../../../" + fileName, Environment.NewLine);
            File.AppendAllText(@"../../../" + fileName, maxDepthOfRecursion.ToString());
            File.AppendAllText(@"../../../" + fileName, Environment.NewLine);
            File.AppendAllText(@"../../../" + fileName, time.ToString());
        }

        public static int[] GetRowsAndColumns(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int[] rowsAndColumns = lines[0].Split(new Char[] { ',', ' ' }).Select(int.Parse).ToArray();
            return rowsAndColumns;
        }
    }
}

