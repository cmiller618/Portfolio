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
    public class KnightTests
    {
        [TestMethod()]
        public void GetEvaluationBoardTest()
        {
            Knight knight = new Knight();
            knight.IsWhite = true;

            Board board = new Board();
            board.StartingBoard();

            Assert.IsNotNull(board);
            Assert.IsNotNull(board.ChessBoard);

            var evalBoard = knight.GetEvaluationBoard(board);
            Assert.IsNotNull(evalBoard);
        }
    }
}