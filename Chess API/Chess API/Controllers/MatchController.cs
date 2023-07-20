using Chess_API.Models;
using Chess_API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Chess_API.Controllers;

public class MatchController : ControllerBase
{
    private readonly MatchService _service;

    public MatchController(MatchService service) 
    { 
        _service = service; 
    }


    public List<Match> FindAll()
    {
        return _service.FindAll();
    }

    public List<PlayerStats> FindTopFive()
    {
        return _service.FindTopFive();
    }

    public IActionResult FindMatchesByProfileId(int profileId)
    {
        List<Match> playersMatches = _service.FindMatchesByProfileId(profileId);
        if (playersMatches.Count() == 0)
        {
            return NotFound();
        }
        return Ok(playersMatches);
    }

    public IActionResult AddMatch(Match match)
    {
        Result<Match> result = new Result<Match>();
        try
        {
            if (match == null)
            {
                throw new NullReferenceException();
            }
            result = _service.AddMatch(match);

            if (result.isSuccess())
            {
                return Ok();
            }
        }
        catch (NullReferenceException)
        {
            return BadRequest();
        }

        return BadRequest(result);
    }

    public IActionResult UpdateMatch(int matchId, Match match)
    {

        if (match == null)
        {
            return BadRequest("Match cannot be null");
        }

        if (matchId != match.MatchId)
        {
            return Conflict("Match Ids do not match");
        }

        Result<Match> result = _service.UpdateMatch(match);

        if (result.isSuccess())
        {
            return Ok();
        }

        return BadRequest(result);
    }
}

