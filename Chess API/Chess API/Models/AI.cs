using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    public class AI
    {
        public bool RandomizeMove(Board board)
        {
            List<(int, int, int, int)> validMoves = new List<(int, int, int, int)>();
            for(int y = 0; y < 8; y++)
            {
                for(int x = 0; x < 8; x++)
                {
                    validMoves.AddRange(FindValidMoves(x, y, board));
                }
            }

            Random random = new Random();
            int index = random.Next(validMoves.Count);
            var randomMove = validMoves[index];
            return board.ChessBoard[randomMove.Item1, randomMove.Item2].Movement(randomMove.Item1, randomMove.Item2, randomMove.Item3, randomMove.Item4, board);

        }
        public List<(int, int, int, int)> FindValidMoves(int x, int y, Board board)
        {
            List<(int, int, int, int)> validMoves = new List<(int, int, int, int)>();

            if (board.ChessBoard[x, y] != null)
            {
                Piece piece = board.ChessBoard[x, y];

                for (int row = 0; row < 8; row++)
                {
                    for (int col = 0; col < 8; col++)
                    {
                        if (piece.ValidMovement(x, y, col, row, board))
                        {
                            validMoves.Add((x, y, col, row));
                        }
                    }
                }
            }

            return validMoves;
        }

    }
}
