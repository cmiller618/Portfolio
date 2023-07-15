using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    public class Queen : Piece
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
                    + ",Queen");
                return true;
            }

            return false;
        }

        public bool ValidMovement(int x, int y, int newX, int newY, Board board)
        {
            int deltaX = Math.Abs(newX - x);
            int deltaY = Math.Abs(newY - y);

            if (deltaX == deltaY)
            {
                if (x < newX && y < newY)
                {
                    return CheckForPiecesRightUpMovement(x++, y++, newX, newY, board);
                }

                if (x > newX && y < newY)
                {
                    return CheckForPiecesLeftUpMovement(x--, y++, newX, newY, board);
                }

                if (x > newX && y > newY)
                {
                    return CheckForPiecesLeftDownMovement(x--, y--, newX, newY, board);
                }

                if (x < newX && y > newY)
                {
                    return CheckForPiecesRightDownMovement(x++, y--, newX, newY, board);
                }
            }

            if (deltaX == 0 && deltaY > 0)
            {
                if(newY > y)
                {
                    return CheckForPiecesUpMovement(x, y++, newX, newY, board);
                }

                if(newY < y)
                {
                    return CheckForPiecesDownMovement(x, y--, newX, newY, board);
                }
                
            }

            if (deltaY == 0 && deltaX > 0)
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

            return false;

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

        public bool CheckForPiecesRightUpMovement(int x, int y, int newX, int newY, Board board)
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

            return CheckForPiecesRightUpMovement(x++, y++, newX, newY, board);
        }

        public bool CheckForPiecesLeftUpMovement(int x, int y, int newX, int newY, Board board)
        {
            if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                || board.ChessBoard[newX, newY] != null && !board.ChessBoard[newX, newY].IsWhite && IsWhite))
            {
                return true;
            }
            else if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                || board.ChessBoard[newX, newY] != null && board.ChessBoard[newX, newY].IsWhite && !IsWhite))
            {
                return true;
            }
            if (board.ChessBoard[x, y] != null)
            {
                return false;
            }

            return CheckForPiecesLeftUpMovement(x--, y++, newX, newY, board);
        }

        public bool CheckForPiecesLeftDownMovement(int x, int y, int newX, int newY, Board board)
        {
            if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                || board.ChessBoard[newX, newY] != null && !board.ChessBoard[newX, newY].IsWhite && IsWhite))
            {
                return true;
            }
            else if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                || board.ChessBoard[newX, newY] != null && board.ChessBoard[newX, newY].IsWhite && !IsWhite))
            {
                return true;
            }
            if (board.ChessBoard[x, y] != null)
            {
                return false;
            }

            return CheckForPiecesLeftDownMovement(x--, y--, newX, newY, board);
        }

        public bool CheckForPiecesRightDownMovement(int x, int y, int newX, int newY, Board board)
        {
            if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                || board.ChessBoard[newX, newY] != null && !board.ChessBoard[newX, newY].IsWhite && IsWhite))
            {
                return true;
            }
            else if (x == newX && y == newY && (board.ChessBoard[newX, newY] == null
                || board.ChessBoard[newX, newY] != null && board.ChessBoard[newX, newY].IsWhite && !IsWhite))
            {
                return true;
            }
            if (board.ChessBoard[x, y] != null)
            {
                return false;
            }

            return CheckForPiecesRightDownMovement(x++, y--, newX, newY, board);
        }
    }
}
