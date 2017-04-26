using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class BFS 
    {
        public GameBoard InitialBoard { get; set; }

        //private PossibleMoves possibleMoves;

        public BFS(string filePath)
        {
            InitialBoard = new GameBoard(filePath);
        }

        public GameBoard Search() //include checking if solution is found
        {
            int numberofIteretions = 0;
            Queue<GameBoard> queue = new Queue<GameBoard>();
            queue.Enqueue(InitialBoard);
            while (queue.Count > 0)
            {
                GameBoard currentBoard = queue.Dequeue();
                if (currentBoard.IsPuzzleSolved())
                {
                    return currentBoard;
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LRUD.ToString())
                {
                    currentBoard.Adjacents.Add(CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateUp(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LRD.ToString())
                {
                    currentBoard.Adjacents.Add(CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LUD.ToString())
                {
                    currentBoard.Adjacents.Add(CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateUp(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LRU.ToString())
                {
                    currentBoard.Adjacents.Add(CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateUp(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.RUD.ToString())
                {
                    currentBoard.Adjacents.Add(CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateUp(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.RD.ToString())
                {
                    currentBoard.Adjacents.Add(CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LD.ToString())
                {
                    currentBoard.Adjacents.Add(CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateDown(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.LU.ToString())
                {
                    currentBoard.Adjacents.Add(CreateStateLeft(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateUp(currentBoard));
                }
                if (currentBoard.PossibleMoves == PossibleMoves.RU.ToString())
                {
                    currentBoard.Adjacents.Add(CreateStateRight(currentBoard));
                    currentBoard.Adjacents.Add(CreateStateUp(currentBoard));
                }
                foreach (GameBoard board in currentBoard.Adjacents)
                {
                    queue.Enqueue(board);
                }
                numberofIteretions++;
                Console.WriteLine(numberofIteretions);
            }
            return null;
        }

        public GameBoard CreateStateRight(GameBoard board)
        {
            GameBoard newState = new GameBoard();
            newState.ParentBoard = board;
            newState.Puzzles = CopyValues(board.Puzzles);
            newState.FreeSpacePosition = SetFreeSpacePosition(board.Puzzles);
            newState.SwapRight();
            newState.Move = (char)Moves.Right;
            newState.SetFreeSpacePosition();
            newState.SetPossibleMoves();
            return newState;
        }

        public GameBoard CreateStateLeft(GameBoard board)
        {
            GameBoard newState = new GameBoard();
            newState.ParentBoard = board;
            newState.Puzzles = CopyValues(board.Puzzles);
            newState.FreeSpacePosition = SetFreeSpacePosition(board.Puzzles);
            newState.SwapLeft();
            newState.Move = (char)Moves.Left;
            newState.SetFreeSpacePosition();
            newState.SetPossibleMoves();
            return newState;
        }

        public GameBoard CreateStateUp(GameBoard board)
        {
            GameBoard newState = new GameBoard();
            newState.ParentBoard = board;
            newState.Puzzles = CopyValues(board.Puzzles);
            newState.FreeSpacePosition = SetFreeSpacePosition(board.Puzzles);
            newState.SwapUp();
            newState.Move = (char)Moves.Up;
            newState.SetFreeSpacePosition();
            newState.SetPossibleMoves();
            return newState;
        }

        public GameBoard CreateStateDown(GameBoard board)
        {
            GameBoard newState = new GameBoard();
            newState.ParentBoard = board;
            newState.Puzzles = CopyValues(board.Puzzles);
            newState.FreeSpacePosition = SetFreeSpacePosition(board.Puzzles);
            newState.SwapDown();
            newState.Move = (char)Moves.Down;
            newState.SetFreeSpacePosition();
            newState.SetPossibleMoves();
            return newState;
        }

        public int[,] CopyValues(int[,] array)
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

        public int[] SetFreeSpacePosition(int[,] array)
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
    }
}
