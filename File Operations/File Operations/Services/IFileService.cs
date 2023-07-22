using File_Operations.Models;

namespace File_Operations.Services;

public interface IFileService
{
    bool CreateFile(CreateFile file);
    bool DeleteFile(DeleteFile file);
    bool RenameFile(RenameFile file);
    bool MoveFile(MoveFile file);
}
