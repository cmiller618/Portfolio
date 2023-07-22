using File_Operations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Operations.DataAccess
{
    public class DirectoryDao : IDirectoryDao
    {
        public bool CreateDirectory(CreateDirectory directory)
        {
            try
            {
                var fullFilePath = directory.FilePath + directory.FileName;
                Directory.CreateDirectory(fullFilePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteDirectory(DeleteDirectory directory)
        {
            try
            {
                var fullOriginalFilePath = directory.FilePath + directory.FileName;
                Directory.Delete(fullOriginalFilePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool MoveDirectory(MoveDirectory directory)
        {
            try
            {
                var fullOriginalFilePath = directory.SourcePath + directory.SourceFileName;
                Directory.Move(fullOriginalFilePath, directory.DestinationPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool RenameDirectory(RenameDirectory directory)
        {
            try
            {
                var fullOriginalFilePath = directory.FilePath + directory.OriginalName;
                var fullNewFilePath = directory.FilePath + directory.NewName;
                Directory.Move(fullOriginalFilePath, fullNewFilePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
