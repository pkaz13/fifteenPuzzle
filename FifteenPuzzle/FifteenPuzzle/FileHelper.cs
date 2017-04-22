﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public static class FileHelper
    {
        //public string EntryFilePath { get; set; }
        //public string SolutionFilePath { get; set; }
        //public string StatsFilePath { get; set; }

        //public string[] Lines { get; set; }

        //private int[] rowsAndColumns;
        //private int[,] data;

        //public FileHelper(string entryFilePath)
        //{
        //    EntryFilePath = entryFilePath;
        //    Lines = File.ReadAllLines(EntryFilePath);
        //}

        //public int[] GetRowsAndColumns()
        //{
        //    rowsAndColumns = Lines[0].Split(new Char[] { ',', ' ' }).Select(int.Parse).ToArray();
        //    return rowsAndColumns;
        //}

        //public int[,] GetData()
        //{
        //    data = new int[rowsAndColumns[0], rowsAndColumns[1]];
        //    for (int i = 0; i < Lines.Length - 1; i++)
        //    {
        //        int[] temp = Lines[i+1].Split(new Char[] { ',', ' ' }).Select(int.Parse).ToArray();
        //        for (int j = 0; j < temp.Length; j++)
        //        {
        //            data[i, j] = temp[j];
        //        }
        //    }
        //    return data;
        //}

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
    }
}
