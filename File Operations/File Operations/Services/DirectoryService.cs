using File_Operations.DataAccess;
using File_Operations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Operations.Services
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IDirectoryDao _directoryDao;

        public DirectoryService(IDirectoryDao directoryDao)
        {
            _directoryDao = directoryDao;
        }

        public bool CreateDirectory(CreateDirectory directory)
        {
            try
            {
                if (directory.FilePath == null || directory.FileName == null)
                {
                    throw new Exception("File path or file name not provided");
                }

                return _directoryDao.CreateDirectory(directory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteDirectory(DeleteDirectory directory)
        {
            try
            {
                if (directory.FileName == null)
                {
                    throw new Exception("FilePath Not Provided");
                }

                if (directory.FilePath == null)
                {
                    throw new Exception("File Name not provided");
                }

                return _directoryDao.DeleteDirectory(directory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool MoveDirectory(MoveDirectory directory)
        {
            try
            {
                if (directory.SourceFileName == null || directory.DestinationPath == null)
                {
                    throw new Exception("FilePath Not Provided");
                }

                if (directory.SourceFileName == null)
                {
                    throw new Exception("Original Name or New Name not provided");
                }

                return _directoryDao.MoveDirectory(directory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RenameDirectory(RenameDirectory directory)
        {
            try
            {
                if (directory.FilePath == null)
                {
                    throw new Exception("FilePath Not Provided");
                }

                if (directory.NewName == null || directory.OriginalName == null)
                {
                    throw new Exception("Original Name or New Name not provided");
                }

                return _directoryDao.RenameDirectory(directory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
