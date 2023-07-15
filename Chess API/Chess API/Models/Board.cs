using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    public class Board
    {
        public Piece[,] ChessBoard { get; set; } = new Piece[8, 8];
        public List<string> LastMove { get; set; } = new List<string>();

        public Piece[,] StartingBoard()
        {
            ChessBoard[0, 0] = new Rook();
            ChessBoard[0, 0].IsWhite = true;
            ChessBoard[1, 0] = new Knight();
            ChessBoard[1, 0].IsWhite = true;
            ChessBoard[2, 0] = new Bishop();
            ChessBoard[2, 0].IsWhite = true;
            ChessBoard[3, 0] = new Queen();
            ChessBoard[3, 0].IsWhite = true;
            ChessBoard[4, 0] = new King();
            ChessBoard[4, 0].IsWhite = true;
            ChessBoard[5, 0] = new Bishop();
            ChessBoard[5, 0].IsWhite = true;
            ChessBoard[6, 0] = new Knight();
            ChessBoard[6, 0].IsWhite = true;
            ChessBoard[7, 0] = new Rook();
            ChessBoard[7, 0].IsWhite = true;

            ChessBoard[0, 7] = new Rook();
            ChessBoard[0, 7].IsWhite = false;
            ChessBoard[1, 7] = new Knight();
            ChessBoard[1, 7].IsWhite = false;
            ChessBoard[2, 7] = new Bishop();
            ChessBoard[2, 7].IsWhite = false;
            ChessBoard[3, 7] = new Queen();
            ChessBoard[3, 7].IsWhite = false;
            ChessBoard[4, 7] = new King();
            ChessBoard[4, 7].IsWhite = false;
            ChessBoard[5, 7] = new Bishop();
            ChessBoard[5, 7].IsWhite = false;
            ChessBoard[6, 7] = new Knight();
            ChessBoard[6, 7].IsWhite = false;
            ChessBoard[7, 7] = new Rook();
            ChessBoard[7, 7].IsWhite = false;

            for(int i = 0; i <= 7; i++)
            {
                ChessBoard[i, 1] = new Pawn();
                ChessBoard[i, 1].IsWhite = true;
                ChessBoard[i, 6] = new Pawn();
                ChessBoard[i, 6].IsWhite = false;
            }
            return ChessBoard;
        }
    }
}
