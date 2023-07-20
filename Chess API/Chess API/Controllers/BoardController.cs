using Chess_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chess_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardController : ControllerBase
{
    private readonly Board _board;

    public BoardController()
    {
        _board = new Board();
    }

    [Produces(typeof(Piece[,]))]
    [HttpGet("current-board")]
    public IActionResult GetCurrentBoard(int turn)
    {
        try
        {
            Piece[,] board = new Piece[8,8];
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
