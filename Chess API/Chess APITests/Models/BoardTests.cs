using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_API.Models.Tests
{
    [TestClass()]
    public class BoardTests
    {
        [TestMethod()]
        public void StartingBoardTest()
        {
            Board board = new Board();
            Piece[,] chessboard = board.StartingBoard();
            Assert.IsNotNull(chessboard);
            Assert.IsNotNull(chessboard[0, 0]);
            Assert.IsNotNull(chessboard[1, 6]);
        }
    }
}