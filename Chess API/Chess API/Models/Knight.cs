using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    public class Knight : Piece
    {
        public bool HasMoved { get; set; }
        public string PieceFile { get; set; }
        public bool IsWhite { get; set; }
        public int PieceValue { get; set; }

        public int[,] GetEvaluationBoard(Board board)
        {
            int[,] EvaluationBoard = new int[8, 8];

            // Assigning evaluation values for knights
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board.ChessBoard[col, row] is Knight)
                    {
                        EvaluationBoard[col, row] = CalculateKnightEvaluation(col, row, board);
                    }
                }
            }

            return EvaluationBoard;
        }

        private int CalculateKnightEvaluation(int col, int row, Board board)
        {
            int evaluation = 3; // Base evaluation value for the knight

            int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
            int[] dy = { -2, -1, 1, 2, 2, 1, -1, -2 };

            for (int i = 0; i < 8; i++)
            {
                int nx = col + dx[i];
                int ny = row + dy[i];

                if (nx >= 0 && nx < 8 && ny >= 0 && ny < 8 && board.ChessBoard[nx, ny] == null)
                {
                    evaluation += GetKnightEvaluationValue(nx, ny, dx, dy, board);
                }
            }

            return evaluation;
        }

        private int GetKnightEvaluationValue(int col, int row, int[] dx, int[] dy, Board board)
        {
            int evaluation = 0;

            for (int i = 0; i < 8; i++)
            {
                int nx = col + dx[i];
                int ny = row + dy[i];

                if (nx >= 0 && nx < 8 && ny >= 0 && ny < 8 && board.ChessBoard[nx, ny] == null)
                {
                    evaluation += 1;
                }
            }

            return evaluation;
        }


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
