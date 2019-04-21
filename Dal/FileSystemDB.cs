using System;
using Softwave_Server_Side.Models;

namespace Softwave_Server_Side.Dal
{
    public class FileSystemDB : IDatabse<MessageDetails>
    {
        private string m_path;

        #region Constructor
        public FileSystemDB()
        {
            m_path = string.Empty;
        }

        public FileSystemDB(string path)
        {
            m_path = path;
        }
        #endregion

        #region Public Methods
        public void CreateEntity(MessageDetails entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}