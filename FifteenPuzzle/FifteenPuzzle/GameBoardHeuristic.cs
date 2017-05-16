using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class GameBoardHeuristic
    {
        public int[,] Puzzles { get; set; }
        public int EmptyRow { get; set; }
        public int EmptyCol { get; set; }

        public char MoveChar { get; set; }
        public string MovesMade { get; set; }

        private int[,] solvedPuzzle;
        private const string solvedFilePath = @"../../../solved.txt";

        public int PathCost { get; set; }
        public int HeuristicValue { get; set; }
        public int F { get; set; }

        public GameBoardHeuristic(string filePath)
        {
            solvedPuzzle = FileHelper.InitBoard(solvedFilePath);
            Puzzles = FileHelper.InitBoard(filePath);
            PathCost = 0;
            HeuristicValue = 0;
            SetFreeSpacePosition();
            MovesMade = "";
        }

        public GameBoardHeuristic(GameBoardHeuristic heuristic)
        {
            solvedPuzzle = FileHelper.InitBoard(solvedFilePath);
            Puzzles = heuristic.Puzzles;
            EmptyRow = heuristic.EmptyRow;
            EmptyCol = heuristic.EmptyCol;
            PathCost = 0;
            ManhattanDistance();
        }

        public void ManhattanDistance()
        {
            HeuristicValue = 0;
            int count = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (count == 16)
                        continue;

                    int[] position = FindSpecificNumber(count);
                    HeuristicValue += Math.Abs(i - position[0]) + Math.Abs(j - position[1]);
                    count++;
                }
            }
            int[] positionFreeSpace = FindSpecificNumber(0);
            HeuristicValue += Math.Abs(3 - positionFreeSpace[0]) + Math.Abs(3 - positionFreeSpace[1]);
        }

        //public void HammingDistance()
        //{
        //    HeuristicValue = 0;
        //    int count = 1;
        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < 4; j++)
        //        {
        //            if (count == 16)
        //                continue;
                    
        //        }
        //    }
        //}

        private int[] FindSpecificNumber(int number)
        {
            int[] foundNoPosition = new int[2];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Puzzles[i, j] == number)
                    {
                        foundNoPosition[0] = i;
                        foundNoPosition[1] = j;
                    }
                }
            }
            return foundNoPosition;
        }

        public bool Move(int direction)
        {
            if (direction < 0 || direction > 3)
                return false;

            //move up
            if (direction == 0 && EmptyRow > 0)
            {
                int temp = Puzzles[EmptyRow, EmptyCol];
                Puzzles[EmptyRow, EmptyCol] = Puzzles[EmptyRow - 1, EmptyCol];
                Puzzles[EmptyRow - 1, EmptyCol] = temp;
                EmptyRow--;
                MoveChar = (char)Moves.Up;
                return true;
            }
            //move right
            if (direction == 1 && EmptyCol < 3)
            {
                int temp = Puzzles[EmptyRow, EmptyCol];
                Puzzles[EmptyRow, EmptyCol] = Puzzles[EmptyRow, EmptyCol + 1];
                Puzzles[EmptyRow, EmptyCol + 1] = temp;
                EmptyCol++;
                MoveChar = (char)Moves.Right;
                return true;
            }
            //move down
            if (direction == 2 && EmptyRow < 3)
            {
                int temp = Puzzles[EmptyRow, EmptyCol];
                Puzzles[EmptyRow, EmptyCol] = Puzzles[EmptyRow + 1, EmptyCol];
                Puzzles[EmptyRow + 1, EmptyCol] = temp;
                EmptyRow++;
                MoveChar = (char)Moves.Down;
                return true;
            }
            //move left
            if (direction == 3 && EmptyCol > 0)
            {
                int temp = Puzzles[EmptyRow, EmptyCol];
                Puzzles[EmptyRow, EmptyCol] = Puzzles[EmptyRow, EmptyCol - 1];
                Puzzles[EmptyRow, EmptyCol - 1] = temp;
                EmptyCol--;
                MoveChar = (char)Moves.Left;
                return true;
            }
            return false;
        }

        public GameBoardHeuristic Copy(string filePath)
        {
            GameBoardHeuristic copiedBoard = new GameBoardHeuristic(filePath);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    copiedBoard.Puzzles[i, j] = Puzzles[i, j];
                }
            }
            copiedBoard.EmptyRow = EmptyRow;
            copiedBoard.EmptyCol = EmptyCol;
            copiedBoard.PathCost = PathCost;
            copiedBoard.HeuristicValue = HeuristicValue;
            copiedBoard.MovesMade = MovesMade;
            return copiedBoard;
        }

        public bool IsPuzzleSolved()
        {
            return (Puzzles.Rank == solvedPuzzle.Rank &&
                Enumerable.Range(0, Puzzles.Rank).All(dimension => Puzzles.GetLength(dimension) == solvedPuzzle.GetLength(dimension)) &&
                Puzzles.Cast<int>().SequenceEqual(solvedPuzzle.Cast<int>()));
        }

        public bool MoveCountingPathCost(int direction)
        {
            if (Move(direction))
            {
                PathCost++;
                ManhattanDistance();
                CountF();
                MovesMade += MoveChar;
                return true;
            }
            return false;
        }

        public void CountF()
        {
            F = PathCost + HeuristicValue;
        }

        private void SetFreeSpacePosition()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Puzzles[i, j] == 0)
                    {
                        EmptyRow = i;
                        EmptyCol = j;
                    }
                }
            }
        }
    }
}
