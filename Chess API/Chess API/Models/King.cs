using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    public class King : Piece
    {
        public bool HasMoved { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PieceFile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsWhite { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Movement(int x, int y, int newX, int newY, Board board)
        {
            throw new NotImplementedException();
        }

        public bool ValidMovement(int x, int y, int newX, int newY, Board board)
        {
            throw new NotImplementedException();
        }
    }
}
