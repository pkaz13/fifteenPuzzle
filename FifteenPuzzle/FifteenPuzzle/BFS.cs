using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class BFS 
    {
        public int[,] SolvedPuzzle { get; set; }

        public BFS()
        {

        }
        
        public bool IsPuzzleSolved(int[,] array)
        {
            return (array.Rank == SolvedPuzzle.Rank &&
                Enumerable.Range(0, array.Rank).All(dimension => array.GetLength(dimension) == SolvedPuzzle.GetLength(dimension)) &&
                array.Cast<int>().SequenceEqual(SolvedPuzzle.Cast<int>()));
        }

        public void CreateStates(GameBoard board)
        {
            GameBoard[] states = new GameBoard[4];
            GameBoard up = null;
            GameBoard down = null;
            GameBoard right = null;
            GameBoard left = null;

            if (board.PossibleMoves == PossibleMoves.LRUD.ToString())
            {
                up = new GameBoard();
                up.Puzzles = board.Puzzles;
                up.FreeSpacePosition = board.FreeSpacePosition;
                up.SwapUp();
                //update
                up.Move = (char)Moves.Up;
                up.SetFreeSpacePosition();
                up.SetPossibleMoves();

                down = new GameBoard();
                down.Puzzles = board.Puzzles;
                down.FreeSpacePosition = board.FreeSpacePosition;
                down.SwapDown();
                //update
                down.Move = (char)Moves.Down;
                down.SetFreeSpacePosition();
                down.SetPossibleMoves();

                right = new GameBoard();
                right.Puzzles = board.Puzzles;
                right.FreeSpacePosition = board.FreeSpacePosition;
                right.SwapRight();
                //update
                right.Move = (char)Moves.Right;
                right.SetFreeSpacePosition();
                right.SetPossibleMoves();

                left = new GameBoard();
                left.Puzzles = board.Puzzles;
                left.FreeSpacePosition = board.FreeSpacePosition;
                left.SwapLeft();
                //update
                left.Move = (char)Moves.Left;
                left.SetFreeSpacePosition();
                left.SetPossibleMoves();
            }

            if (board.PossibleMoves == PossibleMoves.LRD.ToString())
            {
                down = new GameBoard();
                down.Puzzles = board.Puzzles;
                down.FreeSpacePosition = board.FreeSpacePosition;
                down.SwapDown();
                //update
                down.Move = (char)Moves.Down;
                down.SetFreeSpacePosition();
                down.SetPossibleMoves();

                right = new GameBoard();
                right.Puzzles = board.Puzzles;
                right.FreeSpacePosition = board.FreeSpacePosition;
                right.SwapRight();
                //update
                right.Move = (char)Moves.Right;
                right.SetFreeSpacePosition();
                right.SetPossibleMoves();

                left = new GameBoard();
                left.Puzzles = board.Puzzles;
                left.FreeSpacePosition = board.FreeSpacePosition;
                left.SwapLeft();
                //update
                left.Move = (char)Moves.Left;
                left.SetFreeSpacePosition();
                left.SetPossibleMoves();
            }

            if (board.PossibleMoves == PossibleMoves.LUD.ToString())
            {
                up = new GameBoard();
                up.Puzzles = board.Puzzles;
                up.FreeSpacePosition = board.FreeSpacePosition;
                up.SwapUp();
                //update
                up.Move = (char)Moves.Up;
                up.SetFreeSpacePosition();
                up.SetPossibleMoves();

                down = new GameBoard();
                down.Puzzles = board.Puzzles;
                down.FreeSpacePosition = board.FreeSpacePosition;
                down.SwapDown();
                //update
                down.Move = (char)Moves.Down;
                down.SetFreeSpacePosition();
                down.SetPossibleMoves();

                left = new GameBoard();
                left.Puzzles = board.Puzzles;
                left.FreeSpacePosition = board.FreeSpacePosition;
                left.SwapLeft();
                //update
                left.Move = (char)Moves.Left;
                left.SetFreeSpacePosition();
                left.SetPossibleMoves();
            }

            if (board.PossibleMoves == PossibleMoves.LRU.ToString())
            {
                up = new GameBoard();
                up.Puzzles = board.Puzzles;
                up.FreeSpacePosition = board.FreeSpacePosition;
                up.SwapUp();
                //update
                up.Move = (char)Moves.Up;
                up.SetFreeSpacePosition();
                up.SetPossibleMoves();

                right = new GameBoard();
                right.Puzzles = board.Puzzles;
                right.FreeSpacePosition = board.FreeSpacePosition;
                right.SwapRight();
                //update
                right.Move = (char)Moves.Right;
                right.SetFreeSpacePosition();
                right.SetPossibleMoves();

                left = new GameBoard();
                left.Puzzles = board.Puzzles;
                left.FreeSpacePosition = board.FreeSpacePosition;
                left.SwapLeft();
                //update
                left.Move = (char)Moves.Left;
                left.SetFreeSpacePosition();
                left.SetPossibleMoves();
            }

            if (board.PossibleMoves == PossibleMoves.RUD.ToString())
            {
                up = new GameBoard();
                up.Puzzles = board.Puzzles;
                up.FreeSpacePosition = board.FreeSpacePosition;
                up.SwapUp();
                //update
                up.Move = (char)Moves.Up;
                up.SetFreeSpacePosition();
                up.SetPossibleMoves();

                down = new GameBoard();
                down.Puzzles = board.Puzzles;
                down.FreeSpacePosition = board.FreeSpacePosition;
                down.SwapDown();
                //update
                down.Move = (char)Moves.Down;
                down.SetFreeSpacePosition();
                down.SetPossibleMoves();

                right = new GameBoard();
                right.Puzzles = board.Puzzles;
                right.FreeSpacePosition = board.FreeSpacePosition;
                right.SwapRight();
                //update
                right.Move = (char)Moves.Right;
                right.SetFreeSpacePosition();
                right.SetPossibleMoves();
            }

            if (board.PossibleMoves == PossibleMoves.RD.ToString())
            {
                down = new GameBoard();
                down.Puzzles = board.Puzzles;
                down.FreeSpacePosition = board.FreeSpacePosition;
                down.SwapDown();
                //update
                down.Move = (char)Moves.Down;
                down.SetFreeSpacePosition();
                down.SetPossibleMoves();

                right = new GameBoard();
                right.Puzzles = board.Puzzles;
                right.FreeSpacePosition = board.FreeSpacePosition;
                right.SwapRight();
                //update
                right.Move = (char)Moves.Right;
                right.SetFreeSpacePosition();
                right.SetPossibleMoves();
            }

            if (board.PossibleMoves == PossibleMoves.LD.ToString())
            {
                down = new GameBoard();
                down.Puzzles = board.Puzzles;
                down.FreeSpacePosition = board.FreeSpacePosition;
                down.SwapDown();
                //update
                down.Move = (char)Moves.Down;
                down.SetFreeSpacePosition();
                down.SetPossibleMoves();

                left = new GameBoard();
                left.Puzzles = board.Puzzles;
                left.FreeSpacePosition = board.FreeSpacePosition;
                left.SwapLeft();
                //update
                left.Move = (char)Moves.Left;
                left.SetFreeSpacePosition();
                left.SetPossibleMoves();
            }

            if (board.PossibleMoves == PossibleMoves.LU.ToString())
            {
                up = new GameBoard();
                up.Puzzles = board.Puzzles;
                up.FreeSpacePosition = board.FreeSpacePosition;
                up.SwapUp();
                //update
                up.Move = (char)Moves.Up;
                up.SetFreeSpacePosition();
                up.SetPossibleMoves();
                 
                left = new GameBoard();
                left.Puzzles = board.Puzzles;
                left.FreeSpacePosition = board.FreeSpacePosition;
                left.SwapLeft();
                //update
                left.Move = (char)Moves.Left;
                left.SetFreeSpacePosition();
                left.SetPossibleMoves();
            }

            if (board.PossibleMoves == PossibleMoves.RU.ToString())
            {
                up = new GameBoard();
                up.Puzzles = board.Puzzles;
                up.FreeSpacePosition = board.FreeSpacePosition;
                up.SwapUp();
                //update
                up.Move = (char)Moves.Up;
                up.SetFreeSpacePosition();
                up.SetPossibleMoves();

                right = new GameBoard();
                right.Puzzles = board.Puzzles;
                right.FreeSpacePosition = board.FreeSpacePosition;
                right.SwapRight();
                //update
                right.Move = (char)Moves.Right;
                right.SetFreeSpacePosition();
                right.SetPossibleMoves();
            }

        }

        //private int[,] SwapUp(int[,] array, int i, int j)   //i, j - current 0 position
        //{
        //    int tempValue = array[i - 1, j];
        //    array[i - 1, j] = 0;
        //    array[i, j] = tempValue;
        //    return array;
        //}

        //private int[,] SwapDown(int[,] array, int i, int j)
        //{
        //    int tempValue = array[i + 1, j];
        //    array[i + 1, j] = 0;
        //    array[i, j] = tempValue;
        //    return array;
        //}

        //private int[,] SwapLeft(int[,] array, int i, int j)
        //{
        //    int tempValue = array[i, j - 1];
        //    array[i, j - 1] = 0;
        //    array[i, j] = tempValue;
        //    return array;
        //}

        //private int[,] SwapRight(int[,] array, int i, int j)
        //{
        //    int tempValue = array[i, j + 1];
        //    array[i, j + 1] = 0;
        //    array[i, j] = tempValue;
        //    return array;
        //}

        //public string CheckPossibleMoves(int[,] array)
        //{
        //    char[] possibleMoves;
        //    string moves = String.Empty;
        //    //int[,] array = board.Puzzles;

        //    int[] position = CheckFreeSpacePosition(array);

        //    if ((position[0] == 1 && position[1] == 1) || (position[0] == 1 && position[1] == 2) ||
        //        (position[0] == 2 && position[1] == 1) || (position[0] == 2 && position[1] == 2))
        //    {
        //        possibleMoves = new char[4];
        //        possibleMoves[0] = (char)Moves.Left;
        //        possibleMoves[1] = (char)Moves.Right;
        //        possibleMoves[2] = (char)Moves.Up;
        //        possibleMoves[3] = (char)Moves.Down;
        //        moves = new string(possibleMoves);  //LRUD
        //    }

        //    if ((position[0] == 0 && position[1] == 1) || (position[0] == 0 && position[1] == 2))
        //    {
        //        possibleMoves = new char[3];
        //        possibleMoves[0] = (char)Moves.Left;
        //        possibleMoves[1] = (char)Moves.Right;
        //        possibleMoves[2] = (char)Moves.Down;
        //        moves = new string(possibleMoves);  //LRD
        //    }

        //    if ((position[0] == 1 && position[1] == 3) || (position[0] == 2 && position[1] == 3))
        //    {
        //        possibleMoves = new char[3];
        //        possibleMoves[0] = (char)Moves.Left;
        //        possibleMoves[1] = (char)Moves.Up;
        //        possibleMoves[2] = (char)Moves.Down;
        //        moves = new string(possibleMoves);  //LUD
        //    }

        //    if ((position[0] == 3 && position[1] == 1) || (position[0] == 3 && position[1] == 2))
        //    {
        //        possibleMoves = new char[3];
        //        possibleMoves[0] = (char)Moves.Left;
        //        possibleMoves[1] = (char)Moves.Right;
        //        possibleMoves[2] = (char)Moves.Up;
        //        moves = new string(possibleMoves);  //LRU
        //    }

        //    if ((position[0] == 1 && position[1] == 0) || (position[0] == 2 && position[1] == 0))
        //    {
        //        possibleMoves = new char[3];
        //        possibleMoves[0] = (char)Moves.Right;
        //        possibleMoves[1] = (char)Moves.Up;
        //        possibleMoves[2] = (char)Moves.Down;
        //        moves = new string(possibleMoves);  //RUD
        //    }

        //    if (position[0] == 0 && position[1] == 0)
        //    {
        //        possibleMoves = new char[2];
        //        possibleMoves[0] = (char)Moves.Right;
        //        possibleMoves[1] = (char)Moves.Down;
        //        moves = new string(possibleMoves);  //RD
        //    }

        //    if (position[0] == 0 && position[1] == 3)
        //    {
        //        possibleMoves = new char[2];
        //        possibleMoves[0] = (char)Moves.Left;
        //        possibleMoves[1] = (char)Moves.Down;
        //        moves = new string(possibleMoves);  //LD
        //    }

        //    if (position[0] == 3 && position[1] == 3)
        //    {
        //        possibleMoves = new char[2];
        //        possibleMoves[0] = (char)Moves.Left;
        //        possibleMoves[1] = (char)Moves.Up;
        //        moves = new string(possibleMoves);  //LU
        //    }

        //    if (position[0] == 3 && position[1] == 0)
        //    {
        //        possibleMoves = new char[2];
        //        possibleMoves[0] = (char)Moves.Right;
        //        possibleMoves[1] = (char)Moves.Up;
        //        moves = new string(possibleMoves);  //RU
        //    }

        //    return moves;
        //}

        //public int[] CheckFreeSpacePosition(int[,] array)
        //{
        //    int[] freeSpacePosition = new int[2];

        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < 4; j++)
        //        {
        //            if(array[i,j] == 0)
        //            {
        //                freeSpacePosition[0] = i;
        //                freeSpacePosition[1] = j;
        //            }
        //        }
        //    }
        //    return freeSpacePosition;
        //}
    }
}
