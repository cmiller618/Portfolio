using Chess_API.Models;
using Chess_API.Repositories;

namespace Chess_API.Services;

public class PlayerService
{
    private readonly PlayerRepository _repository;

    public PlayerService(PlayerRepository repository)
    {
        _repository = repository;
    }


    public List<PlayerProfile> FindAll()
    {
        return _repository.FindAll();
    }

    public PlayerProfile FindById(int profileId)
    {
        return _repository.FindById(profileId);
    }

    public Result<PlayerProfile> AddPlayer(PlayerProfile playerProfile)
    {
        Result<PlayerProfile> result = ValidateNulls(playerProfile);
        if (!result.isSuccess())
        {
            return result;
        }
        if (playerProfile.ProfileId != 0)
        {
            result.addMessage("Profile id cannot be set for 'add' operation.", ResultType.INVALID);
            return result;
        }

        if (result.isSuccess())
        {
            result.Payload = _repository.AddPlayer(playerProfile);
        }

        return result;
    }

    public Result<PlayerProfile> UpdatePlayer(PlayerProfile playerProfile)
    {


        Result<PlayerProfile> result = ValidateNulls(playerProfile);

        if (!result.isSuccess())
        {
            return result;
        }
        if (playerProfile.ProfileId <= 0)
        {
            result.addMessage("Profile Id must be set for 'update'.", ResultType.INVALID);
            return result;
        }

        if (!_repository.updatePlayer(playerProfile))
        {
            result.addMessage("Player could not be updated", ResultType.NOT_FOUND);
        }

        return result;
    }

    public bool DeleteById(int profileId)
    {
        return _repository.DeleteById(profileId);
    }


    private Result<PlayerProfile> ValidateNulls(PlayerProfile playerProfile)
    {
        Result<PlayerProfile> result = new Result<PlayerProfile>();

        if (playerProfile.UserName == null || playerProfile.UserName.Equals(String.Empty))
        {
            result.addMessage("Please Enter a valid name", ResultType.INVALID);
        }

        if (playerProfile.FirstName == null || playerProfile.FirstName.Equals(String.Empty))
        {
            result.addMessage("Please enter a valid password", ResultType.INVALID);
        }

        if (playerProfile.LastName == null || playerProfile.LastName.Equals(String.Empty))
        {
            result.addMessage("Please enter a valid password", ResultType.INVALID);
        }

        if (playerProfile.Email == null || playerProfile.Email.Equals(String.Empty))
        {
            result.addMessage("Please enter a valid email", ResultType.INVALID);
        }

        return result;

    }

}
