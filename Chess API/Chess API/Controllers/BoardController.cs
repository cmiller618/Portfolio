using Chess_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Chess_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly Board _board;

        public BoardController()
        {
            _board = new Board();
        }

        [HttpGet("current-board")]
        public IActionResult GetCurrentBoard(int turn)
        {
            try
            {
                Piece[,] board = null;
                if (turn == 1)
                {
                    board = _board.StartingBoard();
                }
                else
                {
                    board = _board.ChessBoard;
                }

                return Ok(board);
            }
            catch (Exception)
            {
                return NotFound("Current board not found");
            }            
        }
    }
}
