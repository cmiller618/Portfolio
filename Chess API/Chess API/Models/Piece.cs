using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    public interface Piece
    {
        public bool HasMoved { get; set; } //A check for whether a piece has moved. Useful for castling and pawn movement
        public string PieceFile { get; set; } //location of the picture of the piece
        public bool IsWhite { get; set; } // A check if the Piece is a white piece or not
        public int PieceValue { get; set;  }
        public bool ValidMovement(int x, int y, int newX, int newY, Board board);
        public bool Movement(int x, int y, int newX, int newY, Board board);
        public int[,] GetEvaluationBoard(Board board);
    }
}
