using File_Operations.Models;
using File_Operations.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace File_Operations.Controllers
{
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService) 
        {
            _fileService = fileService;
        }

        public IActionResult CreateFile(CreateFile file)
        {
            try
            {
                if (file == null)
                {
                    return BadRequest("Please provide file information");
                }

                if (!_fileService.CreateFile(file))
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

        public IActionResult RenameFile(RenameFile file)
        {
            try
            {
                if (file == null)
                {
                    return BadRequest("Please provide file information");
                }

                if (!_fileService.RenameFile(file))
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

        public IActionResult DeleteFile(DeleteFile file)
        {
            try
            {
                if (file == null)
                {
                    return BadRequest("Please provide file information");
                }

                if (!_fileService.DeleteFile(file))
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

        public IActionResult MoveFile(MoveFile file)
        {
            try
            {
                if (file == null)
                {
                    return BadRequest("Please provide file information");
                }

                if (!_fileService.MoveFile(file))
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
}
