using File_Operations.Models;

namespace File_Operations.Services;

public interface IDirectoryService
{
    bool CreateDirectory(CreateDirectory directory);
    bool DeleteDirectory(DeleteDirectory directory);
    bool MoveDirectory(MoveDirectory directory);
    bool RenameDirectory(RenameDirectory directory);
}
