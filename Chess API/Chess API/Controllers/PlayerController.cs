using Chess_API.Models;
using Chess_API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Chess_API.Controllers;

public class PlayerController : ControllerBase
{
    private readonly PlayerService _service;

    public PlayerController(PlayerService service)
    {
        _service = service;
    }

    public List<PlayerProfile> FindAll()
    {
        return _service.FindAll();
    }

    public IActionResult FindById(int profileId)
    {
        PlayerProfile player = _service.FindById(profileId);
        if(player == null) 
        {
            return NotFound();
        }
        return Ok(player);
    }

    public IActionResult AddPlayer(PlayerProfile playerProfile)
    {

        if(playerProfile == null)
        {
            return BadRequest();
        }

        Result<PlayerProfile> result = _service.AddPlayer(playerProfile);

        if(result.isSuccess())
        {
            return Ok();
        }

        return BadRequest(result);

    }

    public IActionResult UpdatePlayer(int profileId, PlayerProfile playerProfile)
    {
        if (playerProfile == null) 
        {
            return BadRequest("Player Profile cannot be null");
        }

        if(profileId != playerProfile.ProfileId)
        {
            return Conflict();
        }

        Result<PlayerProfile> result = _service.UpdatePlayer(playerProfile);

        if(result.isSuccess()) 
        {
            return Ok();
        }

        return BadRequest(result);
    }

    public IActionResult DeletePlayer(int profileId)
{
        var deleted = _service.DeleteById(profileId);
        if(deleted)
        {
            return Ok();
        }

        return NotFound();
    }
}
