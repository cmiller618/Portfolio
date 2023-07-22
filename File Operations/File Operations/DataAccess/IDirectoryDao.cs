using File_Operations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Operations.DataAccess
{
    public interface IDirectoryDao
    {
        bool DeleteDirectory(DeleteDirectory directory);
        bool MoveDirectory(MoveDirectory directory);
        bool RenameDirectory(RenameDirectory directory);
        bool CreateDirectory(CreateDirectory directory);
    }
}
