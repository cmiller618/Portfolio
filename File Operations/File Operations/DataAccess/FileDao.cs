using File_Operations.Models;
using System.IO;

namespace File_Operations.DataAccess;

public class FileDao : IFileDao
{
    public bool RenameFile(RenameFile file)
    {
        try
        {
            var fullOriginalFilePath = file.FilePath + file.OriginalName;
            var fullNewFilePath = file.FilePath + file.NewName;
            File.Move(fullOriginalFilePath, fullNewFilePath);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        
    }

    public bool CreateFile(CreateFile file)
    {
        try
        {
            var fullFilePath = file.FilePath + file.FileName;
            File.Create(fullFilePath);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool MoveFile(MoveFile file)
    {
        try
        {
            var fullOriginalFilePath = file.SourcePath + file.SourceFileName;
            File.Move(fullOriginalFilePath, file.DestinationPath);
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    public bool DeleteFile(DeleteFile file)
    {
        try
        {
            var fullOriginalFilePath = file.SourcePath + file.SourceFileName;
            File.Delete(fullOriginalFilePath);
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }
}
