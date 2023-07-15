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
    public class PawnTests
    {
        [TestMethod()]
        public void GetEvaluationBoardTest()
        {
            Pawn pawn = new Pawn();
            pawn.IsWhite = true;

            Board board = new Board();
            board.StartingBoard();

            Assert.IsNotNull(board);
            Assert.IsNotNull(board.ChessBoard);

            var evalBoard = pawn.GetEvaluationBoard(board);
            Assert.IsNotNull(evalBoard);
        }
    }
}