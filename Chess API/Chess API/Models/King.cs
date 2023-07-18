using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    public class King : Piece
    {
        public bool HasMoved { get; set; }
        public string PieceFile { get; set; }
        public bool IsWhite { get; set; }
        public int PieceValue { get; set; }

        public bool Movement(int x, int y, int newX, int newY, Board board)
        {
            if (ValidMovement(x, y, newX, newY, board))
            {
                // Perform castling if the king is castling
                if (IsCastlingMove(x, y, newX, newY))
                {
                    PerformCastlingMove(x, y, newX, newY, board);
                }
                else
                {
                    board.ChessBoard[newX, newY] = board.ChessBoard[x, y];
                    board.ChessBoard[x, y] = null;
                    board.LastMove.Add(x.ToString() + "," + y.ToString() + "," + newX.ToString() + "," + newY.ToString() + ",King");
                }

                return true;
            }

            return false;
        }

        public bool ValidMovement(int x, int y, int newX, int newY, Board board)
        {
            int deltaX = Math.Abs(newX - x);
            int deltaY = Math.Abs(newY - y);

            // Check if the movement is within the king's range
            if (deltaX <= 1 && deltaY <= 1)
            {
                // Check if the destination square is unoccupied or contains an opponent's piece
                if (board.ChessBoard[newX, newY] == null || (board.ChessBoard[newX, newY] != null && board.ChessBoard[newX, newY].IsWhite != IsWhite))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsCastlingMove(int x, int y, int newX, int newY)
        {
            // Check if the movement is a castling move
            return Math.Abs(newX - x) == 2 && newY == y;
        }

        private void PerformCastlingMove(int x, int y, int newX, int newY, Board board)
        {
            int rookX;
            int rookNewX;

            if (newX > x)
            {
                // Castling to the right (kingside)
                rookX = 7;
                rookNewX = newX - 1;
            }
            else
            {
                // Castling to the left (queenside)
                rookX = 0;
                rookNewX = newX + 1;
            }

            // Move the king
            board.ChessBoard[newX, newY] = board.ChessBoard[x, y];
            board.ChessBoard[x, y] = null;
            board.LastMove.Add(x.ToString() + "," + y.ToString() + "," + newX.ToString() + "," + newY.ToString() + ",King");

            // Move the rook
            board.ChessBoard[rookNewX, newY] = board.ChessBoard[rookX, newY];
            board.ChessBoard[rookX, newY] = null;
            board.LastMove.Add(rookX.ToString() + "," + newY.ToString() + "," + rookNewX.ToString() + "," + newY.ToString() + ",Rook");
        }

        public int[,] GetEvaluationBoard(Board board)
        {
            int[,] EvaluationBoard = new int[8, 8];

            // Assigning evaluation values for kings
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board.ChessBoard[col, row] is King)
                    {
                        EvaluationBoard[col, row] = CalculateKingEvaluation(col, row, board);
                    }
                }
            }

            return EvaluationBoard;
        }

        private int CalculateKingEvaluation(int col, int row, Board board)
        {
            int evaluation = 10; // Base evaluation value for the king

            // Define the eight possible directions of king's movement
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                int nx = col + dx[i];
                int ny = row + dy[i];

                if (nx >= 0 && nx < 8 && ny >= 0 && ny < 8 && (board.ChessBoard[nx, ny] == null || board.ChessBoard[nx, ny].IsWhite != board.ChessBoard[col, row].IsWhite))
                {
                    evaluation += 1;
                }
            }

            return evaluation;
        }
    }

}
