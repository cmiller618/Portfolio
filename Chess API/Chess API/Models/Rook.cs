using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    public class Rook : Piece
    {
        public bool HasMoved { get; set; }
        public string PieceFile { get; set; }
        public bool IsWhite { get; set; }

        public bool Movement(int x, int y, int newX, int newY, Board board)
        {
            if (ValidMovement(x, y, newX, newY, board))
            {
                board.ChessBoard[newX, newY] = board.ChessBoard[x, y];
                board.ChessBoard[x, y] = null;
                board.LastMove.Add(x.ToString() + "," + y.ToString() + "," + newX.ToString() + "," + newY.ToString()
                    + ",Rook");
                return true;
            }

            return false;
        }

        public bool ValidMovement(int x, int y, int newX, int newY, Board board)
        {
            int deltaX = Math.Abs(newX - x);
            int deltaY = Math.Abs(newY - y);

            if(deltaX > 0 && deltaY > 0)
            {
                return false;
            }

            if(deltaX > deltaY)
            {
                if (newX > x)
                {
                    return CheckForPiecesRightMovement(x++, y, newX, newY, board);
                }

                if (newX < x)
                {
                    return CheckForPiecesLeftMovement(x--, y, newX, newY, board);
                }
            }

            if(deltaY > deltaX)
            {
                if (newY > y)
                {
                    return CheckForPiecesUpMovement(x, y++, newX, newY, board);
                }

                if (newY < y)
                {
                    return CheckForPiecesDownMovement(x, y--, newX, newY, board);
                }
            }
            return false;
        }

        private bool CheckForPiecesDownMovement(int x, int y, int newX, int newY, Board board)
        {
            if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                 || (board.ChessBoard[newX, newY] != null && !board.ChessBoard[newX, newY].IsWhite && IsWhite)))
            {
                return true;
            }
            else if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                || (board.ChessBoard[newX, newY] != null && board.ChessBoard[newX, newY].IsWhite && !IsWhite)))
            {
                return true;
            }
            if (board.ChessBoard[x, y] != null)
            {
                return false;
            }
            return CheckForPiecesDownMovement(x, y--, newX, newY, board);
        }

        private bool CheckForPiecesUpMovement(int x, int y, int newX, int newY, Board board)
        {
            if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                 || (board.ChessBoard[newX, newY] != null && !board.ChessBoard[newX, newY].IsWhite && IsWhite)))
            {
                return true;
            }
            else if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                || (board.ChessBoard[newX, newY] != null && board.ChessBoard[newX, newY].IsWhite && !IsWhite)))
            {
                return true;
            }
            if (board.ChessBoard[x, y] != null)
            {
                return false;
            }
            return CheckForPiecesUpMovement(x, y++, newX, newY, board);
        }

        private bool CheckForPiecesLeftMovement(int x, int y, int newX, int newY, Board board)
        {
            if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                 || (board.ChessBoard[newX, newY] != null && !board.ChessBoard[newX, newY].IsWhite && IsWhite)))
            {
                return true;
            }
            else if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                || (board.ChessBoard[newX, newY] != null && board.ChessBoard[newX, newY].IsWhite && !IsWhite)))
            {
                return true;
            }
            if (board.ChessBoard[x, y] != null)
            {
                return false;
            }
            return CheckForPiecesLeftMovement(x--, y, newX, newY, board);
        }

        private bool CheckForPiecesRightMovement(int x, int y, int newX, int newY, Board board)
        {
            if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                 || (board.ChessBoard[newX, newY] != null && !board.ChessBoard[newX, newY].IsWhite && IsWhite)))
            {
                return true;
            }
            else if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                || (board.ChessBoard[newX, newY] != null && board.ChessBoard[newX, newY].IsWhite && !IsWhite)))
            {
                return true;
            }
            if (board.ChessBoard[x, y] != null)
            {
                return false;
            }
            return CheckForPiecesRightMovement(x++, y, newX, newY, board);
        }

        public int[,] GetEvaluationBoard()
        {
            throw new NotImplementedException();
            
        }
    }
}
