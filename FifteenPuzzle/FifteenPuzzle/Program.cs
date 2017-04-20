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
            string filePath = @"../../../4x4_01_00001.txt";

            FileHelper helper = new FileHelper(filePath);

            int[] temp = helper.GetRowsAndColumns();

            GameBoard board = new GameBoard(temp[0], temp[1]);
            board.Puzzles = helper.GetData();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(string.Format("{0} ", board.Puzzles[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.ReadKey();

        }
    }
}
