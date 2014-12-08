using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Julekalender.knowit
{
    class Luke3
    {
        public static void Run()
        {
            Board board = new Board(10, 10);
            for (int i = 0; i < 200; i++)
            {
                Point move = board.GetMove();
                board.Move(move);
            }
            Console.WriteLine(board.GetNumBlack());
        }
    }
    class Board
    {
        bool[,] boardArray;
        Point position;
        int[,] legalOffsets;
        public Board(int sizeX, int sizeY)
        {
            boardArray = new bool[sizeY,sizeX];
            position = new Point(0,0);
            legalOffsets = new int[,] {{-2, 1},
                                  {-1, 2},
                                  {1, 2},
                                  {2, 1},
                                  {2, -1},
                                  {1, -2},
                                  {-1, -2},
                                  {-2, -1}};
        }
        public Point GetMove()
        {
            List<Point> legalMoves = new List<Point>();
            legalMoves = GetLegalMoves();
            int lowest = boardArray.GetLength(0)*10 + boardArray.GetLength(1);
            Point currentMove = new Point();
            bool currentState = boardArray[position.Y, position.X];
            foreach (Point move in legalMoves)
            {
                if (boardArray[move.Y, move.X] == currentState)
                {
                    int value = (move.Y * 10) + move.X;
                    if (value < lowest)
                    {
                        lowest = value;
                        currentMove = move;
                    }
                }
            }
            if (lowest >= boardArray.GetLength(0) * 10 + boardArray.GetLength(1))
            {
                int highest = -1;
                foreach(Point move in legalMoves)
                {
                    int value = (move.Y * 10) + move.X;
                    if (value > highest)
                    {
                        highest = value;
                        currentMove = move;
                    }
                }
            }
            return currentMove;
        }
        private List<Point> GetLegalMoves()
        {
            List<Point> legalMoves = new List<Point>();
            for (int i = 0; i < legalOffsets.GetLength(0); i++)
            {
                Point pos = new Point(position.X + legalOffsets[i, 1], position.Y + legalOffsets[i, 0]);
                if (isValidPos(pos))
                {
                    legalMoves.Add(pos);
                }
            }
            return legalMoves;
        }
        private bool isValidPos(Point pos)
        {

                if (pos.Y >= 0 && pos.Y < boardArray.GetLength(0) && pos.X >= 0 && pos.X < boardArray.GetLength(1))
                {
                    return true;
                }
                return false;

        }
        public void Move(Point newPos)
        {
            boardArray[position.Y, position.X] = !boardArray[position.Y, position.X];
            position = newPos;
        }
        public int GetNumBlack()
        {
            int sum = 0;
            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for (int j = 0; j < boardArray.GetLength(1); j++)
                {
                    if (boardArray[i, j])
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
    }
}
