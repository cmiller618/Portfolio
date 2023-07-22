using File_Operations.Models;
using File_Operations.Services;
using Microsoft.AspNetCore.Mvc;

namespace File_Operations.Controllers;

public class DirectoryController : ControllerBase
{
    private readonly IDirectoryService _directoryService;

    public DirectoryController(IDirectoryService directoryService)
    {
        _directoryService = directoryService;
    }

    public IActionResult CreateDirectory(CreateDirectory directory)
    {
        try
        {
            if (directory == null)
            {
                return BadRequest("Please provide file information");
            }

            if (!_directoryService.CreateDirectory(directory))
            {
                throw new FileNotFoundException();
            }
        }
        catch (FileNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Accepted();
    }

    public IActionResult RenameFile(RenameDirectory directory)
    {
        try
        {
            if (directory == null)
            {
                return BadRequest("Please provide file information");
            }

            if (!_directoryService.RenameDirectory(directory))
            {
                throw new FileNotFoundException();
            }
        }
        catch (FileNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Accepted();
    }

    public IActionResult DeleteFile(DeleteDirectory directory)
    {
        try
        {
            if (directory == null)
            {
                return BadRequest("Please provide file information");
            }

            if (!_directoryService.DeleteDirectory(directory))
            {
                throw new FileNotFoundException();
            }
        }
        catch (FileNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Accepted();
    }

    public IActionResult MoveDirectory(MoveDirectory directory)
    {
        try
        {
            if (directory == null)
            {
                return BadRequest("Please provide file information");
            }

            if (!_directoryService.MoveDirectory(directory))
            {
                throw new FileNotFoundException();
            }
        }
        catch (FileNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Accepted();
    }
}
