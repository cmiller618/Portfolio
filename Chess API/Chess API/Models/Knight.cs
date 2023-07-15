using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    internal class Knight : Piece
    {
        public bool HasMoved { get; set; }
        public string PieceFile { get; set; }
        public bool IsWhite { get; set; }

        public bool Movement(int x, int y, int newX, int newY, Board board)
        {
            if(ValidMovement(x, y, newX, newY, board))
            {
                board.ChessBoard[newX, newY] = board.ChessBoard[x, y];
                board.ChessBoard[x, y] = null;
                board.LastMove.Add(x.ToString() + "," + y.ToString() + "," + newX.ToString() + "," + newY.ToString()
                    + ",Knight");
                return true;
            }

            return false;
        }

        public bool ValidMovement(int x, int y, int newX, int newY, Board board)
        {
            int deltaX = Math.Abs(newX - x);
            int deltaY = Math.Abs(newY - y);

            if(deltaX > 2 || deltaY > 2)
            {
                return false;
            }

            return (deltaX == 2 && deltaY == 1) || (deltaX == 1 && deltaY == 2) &&
                ((board.ChessBoard[newX, newY] == null) || (board.ChessBoard[newX, newY] != null && (!board.ChessBoard[newX, newY].IsWhite && IsWhite
                || board.ChessBoard[newX, newY].IsWhite && !IsWhite)));
        }
    }
}
