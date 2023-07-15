using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    public class Pawn : Piece
    {
        public bool HasMoved { get; set; } = false;
        public bool IsWhite { get; set; }
        public string PieceFile { get; set; }

        public bool Movement(int x, int y, int newX, int newY, Board board)
        {
            if (ValidMovement(x, y, newX, newY, board))
            {
                board.ChessBoard[newX, newX] = board.ChessBoard[x, y];
                board.ChessBoard[x, y] = null;
                board.LastMove.Add(x.ToString() + "," + y.ToString() + "," + newX.ToString() + "," + newY.ToString()
                    + ",Pawn");

                if (!HasMoved)
                {
                    HasMoved = true;
                }
                return true;
            }

            return false;
        }

        public bool ValidMovement(int x, int y, int newX, int newY, Board board)
        {
            int deltaX = newX - x;
            int deltaY = newY - y;

            if (IsWhite && !HasMoved && deltaY <= 2 && deltaY > 0)
            {
                return true;
            }
            else if (!IsWhite && !HasMoved && deltaY >= -2 && deltaY < 0)
            {
                return true;
            }

            if (IsWhite && deltaY == 1 && board.ChessBoard[newX, newY] == null )
            {
                return true;
            }
            else if (!IsWhite && deltaY == -1 && board.ChessBoard[newX, newY] == null )
            {
                return true;
            }

            if (IsWhite && deltaY == 1 && (deltaX == 1 || deltaX == -1) &&
                board.ChessBoard[newX, newY] != null && !board.ChessBoard[newX, newY].IsWhite)
            {
                return true;
            }
            else if (!IsWhite && deltaY == -1 && (deltaX == 1 || deltaX == -1) && 
                board.ChessBoard[newX, newY] != null && board.ChessBoard[newX, newY].IsWhite)
            {
                return true;
            }

            if(EnPassant(x, y, newX, newY, board))
            {
                return true;
            }

            return false;
        }

        public bool EnPassant(int x, int y, int newX, int newY, Board board)
        {
            var lastMove = board.LastMove[board.LastMove.Count - 1].Split(",");
            int lastMoveY = Int32.Parse(lastMove[1]);
            int lastMoveNewX = Int32.Parse(lastMove[2]);
            int lastMoveNewY = Int32.Parse(lastMove[3]);

            int changeY = lastMoveNewY - lastMoveY;
            int deltaX = Math.Abs(newX - x);
            int deltaY = Math.Abs(newY - y);


            return ((IsWhite && changeY == -2 || !IsWhite && changeY == 2) && deltaX == deltaY 
                && deltaX == 1 && newX == lastMoveNewX && board.ChessBoard[newX, newY] == null);
            

        }
    }
}
