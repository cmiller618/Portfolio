using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    public interface Piece
    {
        public bool HasMoved { get; set; }
        public string PieceFile { get; set; }
        public bool IsWhite { get; set; }
        public bool ValidMovement(int x, int y, int newX, int newY, Board board);
        public bool Movement(int x, int y, int newX, int newY, Board board);
    }
}
