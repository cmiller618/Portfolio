using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models
{
    public class Board
    {
        public Piece[,] ChessBoard { get; set; }
        public List<string> LastMove { get; set; } = new List<string>();
    }
}
