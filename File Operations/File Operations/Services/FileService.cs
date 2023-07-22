using File_Operations.DataAccess;
using File_Operations.Models;

namespace File_Operations.Services;

public class FileService : IFileService
{

    private readonly FileDao _fileDao;

    public FileService(FileDao fileDao)
    {
        _fileDao = fileDao;
    }

    public bool CreateFile(CreateFile file)
    {
        try
        {
            if(file.FilePath == null || file.FileName == null)
            {
                throw new Exception("File path or file name not provided");
            }

            return _fileDao.CreateFile(file);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public bool DeleteFile(DeleteFile file)
    {
        try
        {
            if (file.SourceFileName == null)
            {
                throw new Exception("FilePath Not Provided");
            }

            if (file.SourceFileName == null)
            {
                throw new Exception("File Name not provided");
            }

            return _fileDao.DeleteFile(file);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public bool MoveFile(MoveFile file)
    {
        try
        {
            if (file.SourceFileName == null || file.DestinationPath == null)
            {
                throw new Exception("FilePath Not Provided");
            }

            if (file.SourceFileName == null)
            {
                throw new Exception("Original Name or New Name not provided");
            }

            return _fileDao.MoveFile(file);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public bool RenameFile(RenameFile file)
    {
        try
        {
            if (file.FilePath == null)
            {
                throw new Exception("FilePath Not Provided");
            }

            if(file.NewName == null || file.OriginalName == null)
            {
                throw new Exception("Original Name or New Name not provided");
            }

            return _fileDao.RenameFile(file);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    
}
