using Chess_API.Models;
using Chess_API.Repositories;

namespace Chess_API.Services;

public class MatchService
{
    private readonly MatchRepository _repository;

    public MatchService(MatchRepository repository)
    {
        _repository = repository;
    }

    public List<Match> FindAll()
    {
        return _repository.FindAll();
    }

    public List<PlayerStats> FindTopFive()
    {
        return _repository.FindTopFive();
    }

    public List<Match> FindMatchesByProfileId(int profileId)
    {
        return _repository.FindMatchesByProfileId(profileId);
    }

    public Result<Match> AddMatch(Match match)
    {
        Result<Match> result = ValidateNulls(match);
        if (!result.isSuccess())
        {
            return result;
        }
        if (match.MatchId != 0)
        {
            result.addMessage("Match id cannot be set for 'add' operation.", ResultType.INVALID);
            return result;
        }
        if (match.Player1Id == match.Player2Id)
        {
            result.addMessage("Player id's must be different.", ResultType.INVALID);
            return result;
        }
        if (match.EndTime != null)
        {
            result.addMessage("Match end time cannot be set for 'add' operation", ResultType.INVALID);
            return result;
        }
        if (result.isSuccess())
        {
            result.Payload = _repository.AddMatch(match);
        }

        return result;
    }

    public Result<Match> UpdateMatch(Match match)
    {
        Result<Match> result = ValidateNulls(match);

        if (!result.isSuccess())
        {
            return result;
        }
        if (match.MatchId <= 0)
        {
            result.addMessage("Match id must be set for 'update' operation.", ResultType.INVALID);
            return result;
        }
        if (match.Player1Id == match.Player2Id)
        {
            result.addMessage("Player id's must be different.", ResultType.INVALID);
            return result;
        }
        if (match.PlayerWinnerId != match.Player1Id &&
                match.PlayerWinnerId != match.Player2Id
                && (match.PlayerWinnerId != 0))
        {
            result.addMessage("The winner cannot be a player that did not participate in the game.", ResultType.INVALID);
            return result;
        }
        if (match.PlayerWinnerId != 0 && match.EndTime == null)
        {
            result.addMessage("Cannot update match in progress.", ResultType.INVALID);
            return result;
        }
        if (!_repository.UpdateMatch(match))
        {
            string msg = $"Match Id {match.MatchId} not found";
            result.addMessage(msg, ResultType.NOT_FOUND);
        }
        return result;
    }

    private Result<Match> ValidateNulls(Match match)
    {
        Result<Match> result = new Result<Match>();

        if (match.Player1Id == 0)
        {
            result.addMessage("Player 1 must have a valid id", ResultType.INVALID);
            return result;
        }
        if (match.Player2Id == 0)
        {
            result.addMessage("Player 2 must have a valid id", ResultType.INVALID);
            return result;
        }
        return result;
    }
}
