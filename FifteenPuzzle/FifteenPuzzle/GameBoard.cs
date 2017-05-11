using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class GameBoard
    {
        public GameBoard ParentBoard { get; set; }

        public List<GameBoard> Adjacents { get; set; }

        public char Move { get; set; }

        public string PossibleMoves { get; set; }

        public int[] FreeSpacePosition { get; set; }

        public int[,] Puzzles { get; set; }

        public string MovesMade { get; set; }

        public int Depth { get; set; }

        private int[,] solvedPuzzle;

        private const string solvedFilePath = @"../../../solved.txt";

        public GameBoard()
        {
            FreeSpacePosition = new int[2];
            Adjacents = new List<GameBoard>();
            solvedPuzzle = FileHelper.InitBoard(solvedFilePath);
        }

        public GameBoard(string initialFilePath)
        {
            Puzzles = FileHelper.InitBoard(initialFilePath);
            solvedPuzzle = FileHelper.InitBoard(solvedFilePath);
            FreeSpacePosition = new int[2];
            Adjacents = new List<GameBoard>();
            MovesMade = "";
            SetFreeSpacePosition();
            SetPossibleMoves();
        }

        private void SwapUp()   
        {
            int tempValue = Puzzles[FreeSpacePosition[0] - 1, FreeSpacePosition[1]];
            Puzzles[FreeSpacePosition[0] - 1, FreeSpacePosition[1]] = 0;
            Puzzles[FreeSpacePosition[0], FreeSpacePosition[1]] = tempValue;
        }

        private void SwapDown()
        {
            int tempValue = Puzzles[FreeSpacePosition[0] + 1, FreeSpacePosition[1]];
            Puzzles[FreeSpacePosition[0] + 1, FreeSpacePosition[1]] = 0;
            Puzzles[FreeSpacePosition[0], FreeSpacePosition[1]] = tempValue;
        }

        private void SwapLeft()
        {
            int tempValue = Puzzles[FreeSpacePosition[0], FreeSpacePosition[1] - 1];
            Puzzles[FreeSpacePosition[0], FreeSpacePosition[1] - 1] = 0;
            Puzzles[FreeSpacePosition[0], FreeSpacePosition[1]] = tempValue;
        }

        private void SwapRight()
        {
            int tempValue = Puzzles[FreeSpacePosition[0], FreeSpacePosition[1] + 1];
            Puzzles[FreeSpacePosition[0], FreeSpacePosition[1] + 1] = 0;
            Puzzles[FreeSpacePosition[0], FreeSpacePosition[1]] = tempValue;
        }

        private void SetFreeSpacePosition()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Puzzles[i, j] == 0)
                    {
                        FreeSpacePosition[0] = i;
                        FreeSpacePosition[1] = j;
                    }
                }
            }
        }

        private void SetPossibleMoves()
        {
            char[] possibleMoves;
           
            if ((FreeSpacePosition[0] == 1 && FreeSpacePosition[1] == 1) || (FreeSpacePosition[0] == 1 && FreeSpacePosition[1] == 2) ||
                (FreeSpacePosition[0] == 2 && FreeSpacePosition[1] == 1) || (FreeSpacePosition[0] == 2 && FreeSpacePosition[1] == 2))
            {
                possibleMoves = new char[4];
                possibleMoves[0] = (char)Moves.Left;
                possibleMoves[1] = (char)Moves.Right;
                possibleMoves[2] = (char)Moves.Up;
                possibleMoves[3] = (char)Moves.Down;
                PossibleMoves = new string(possibleMoves);  //LRUD
            }

            if ((FreeSpacePosition[0] == 0 && FreeSpacePosition[1] == 1) || (FreeSpacePosition[0] == 0 && FreeSpacePosition[1] == 2))
            {
                possibleMoves = new char[3];
                possibleMoves[0] = (char)Moves.Left;
                possibleMoves[1] = (char)Moves.Right;
                possibleMoves[2] = (char)Moves.Down;
                PossibleMoves = new string(possibleMoves);  //LRD
            }

            if ((FreeSpacePosition[0] == 1 && FreeSpacePosition[1] == 3) || (FreeSpacePosition[0] == 2 && FreeSpacePosition[1] == 3))
            {
                possibleMoves = new char[3];
                possibleMoves[0] = (char)Moves.Left;
                possibleMoves[1] = (char)Moves.Up;
                possibleMoves[2] = (char)Moves.Down;
                PossibleMoves = new string(possibleMoves);  //LUD
            }

            if ((FreeSpacePosition[0] == 3 && FreeSpacePosition[1] == 1) || (FreeSpacePosition[0] == 3 && FreeSpacePosition[1] == 2))
            {
                possibleMoves = new char[3];
                possibleMoves[0] = (char)Moves.Left;
                possibleMoves[1] = (char)Moves.Right;
                possibleMoves[2] = (char)Moves.Up;
                PossibleMoves = new string(possibleMoves);  //LRU
            }

            if ((FreeSpacePosition[0] == 1 && FreeSpacePosition[1] == 0) || (FreeSpacePosition[0] == 2 && FreeSpacePosition[1] == 0))
            {
                possibleMoves = new char[3];
                possibleMoves[0] = (char)Moves.Right;
                possibleMoves[1] = (char)Moves.Up;
                possibleMoves[2] = (char)Moves.Down;
                PossibleMoves = new string(possibleMoves);  //RUD
            }

            if (FreeSpacePosition[0] == 0 && FreeSpacePosition[1] == 0)
            {
                possibleMoves = new char[2];
                possibleMoves[0] = (char)Moves.Right;
                possibleMoves[1] = (char)Moves.Down;
                PossibleMoves = new string(possibleMoves);  //RD
            }

            if (FreeSpacePosition[0] == 0 && FreeSpacePosition[1] == 3)
            {
                possibleMoves = new char[2];
                possibleMoves[0] = (char)Moves.Left;
                possibleMoves[1] = (char)Moves.Down;
                PossibleMoves = new string(possibleMoves);  //LD
            }

            if (FreeSpacePosition[0] == 3 && FreeSpacePosition[1] == 3)
            {
                possibleMoves = new char[2];
                possibleMoves[0] = (char)Moves.Left;
                possibleMoves[1] = (char)Moves.Up;
                PossibleMoves = new string(possibleMoves);  //LU
            }

            if (FreeSpacePosition[0] == 3 && FreeSpacePosition[1] == 0)
            {
                possibleMoves = new char[2];
                possibleMoves[0] = (char)Moves.Right;
                possibleMoves[1] = (char)Moves.Up;
                PossibleMoves = new string(possibleMoves);  //RU
            }
        }

        private GameBoard CreateStateRight()
        {
            GameBoard newState = new GameBoard();
            newState.ParentBoard = this;
            newState.Puzzles = CopyValues(this.Puzzles);
            newState.FreeSpacePosition = SetFreeSpacePosition(this.Puzzles);
            newState.SwapRight();
            newState.Move = (char)Moves.Right;
            newState.SetFreeSpacePosition();
            newState.SetPossibleMoves();
            newState.MovesMade = this.MovesMade + 'R';
            return newState;
        }

        private GameBoard CreateStateLeft()
        {
            GameBoard newState = new GameBoard();
            newState.ParentBoard = this;
            newState.Puzzles = CopyValues(this.Puzzles);
            newState.FreeSpacePosition = SetFreeSpacePosition(this.Puzzles);
            newState.SwapLeft();
            newState.Move = (char)Moves.Left;
            newState.SetFreeSpacePosition();
            newState.SetPossibleMoves();
            newState.MovesMade = this.MovesMade + 'L';
            return newState;
        }

        private GameBoard CreateStateUp()
        {
            GameBoard newState = new GameBoard();
            newState.ParentBoard = this;
            newState.Puzzles = CopyValues(this.Puzzles);
            newState.FreeSpacePosition = SetFreeSpacePosition(this.Puzzles);
            newState.SwapUp();
            newState.Move = (char)Moves.Up;
            newState.SetFreeSpacePosition();
            newState.SetPossibleMoves();
            newState.MovesMade = this.MovesMade + 'U';
            return newState;
        }

        private GameBoard CreateStateDown()
        {
            GameBoard newState = new GameBoard();
            newState.ParentBoard = this;
            newState.Puzzles = CopyValues(this.Puzzles);
            newState.FreeSpacePosition = SetFreeSpacePosition(this.Puzzles);
            newState.SwapDown();
            newState.Move = (char)Moves.Down;
            newState.SetFreeSpacePosition();
            newState.SetPossibleMoves();
            newState.MovesMade = this.MovesMade + 'D';
            return newState;
        }

        private int[,] CopyValues(int[,] array)
        {
            int[,] newArray = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    newArray[i, j] = array[i, j];
                }
            }
            return newArray;
        }

        private int[] SetFreeSpacePosition(int[,] array)
        {
            int[] newArray = new int[2];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (array[i, j] == 0)
                    {
                        newArray[0] = i;
                        newArray[1] = j;
                    }
                }
            }
            return newArray;
        }

        public GameBoard CreateStateDependingOnChar(char direction)
        {
            GameBoard newState = null;
            if (direction == (char)Moves.Left)
            {
                newState = CreateStateLeft();
            }
            if (direction == (char)Moves.Right)
            {
                newState = CreateStateRight();
            }
            if (direction == (char)Moves.Up)
            {
                newState = CreateStateUp();
            }
            if (direction == (char)Moves.Down)
            {
                newState = CreateStateDown();
            }
            return newState;
        }

        public bool CheckIfMoveIsPossible(char move, char[] possibleMoves)
        {
            if (possibleMoves.Contains(move))
                return true;
            else
                return false;
        }

        public bool IsPuzzleSolved()
        {
            return (Puzzles.Rank == solvedPuzzle.Rank &&
                Enumerable.Range(0, Puzzles.Rank).All(dimension => Puzzles.GetLength(dimension) == solvedPuzzle.GetLength(dimension)) &&
                Puzzles.Cast<int>().SequenceEqual(solvedPuzzle.Cast<int>()));
        }

        public int GetDepthOfState()
        {
            GameBoard temp = this;
            int depth = 0;
            while (temp.ParentBoard != null)
            {
                depth++;
                temp = temp.ParentBoard;
            }
            Depth = depth;
            return depth;
        }

        public int HammingDistance()
        {
            int distance = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Puzzles[i, j] != solvedPuzzle[i, j])
                        distance++;
                }
            }
            return distance;
        }

        public int ManhattanDistance()
        {
            int distance = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int NoOnBoard = Puzzles[i, j];
                    if (NoOnBoard != 0)
                    {
                        int targetI = (NoOnBoard - 1) / 4; //expected row coordinate
                        int targetJ = (NoOnBoard - 1) / 4; //expected column coordinate
                        int di = i - targetI;   //distance to expected row coordinate
                        int dj = j - targetJ;   //distance to expected column coordinate
                        distance += Math.Abs(di) + Math.Abs(dj);
                    }
                }
            }
            return distance;

        }

        private int[] FindSpecificNumber(int number)
        {
            int[] foundNoPosition = new int[2];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Puzzles[i,j] == number)
                    {
                        foundNoPosition[0] = i;
                        foundNoPosition[1] = j;
                    }
                }
            }
            return foundNoPosition;
        }
    }
}
