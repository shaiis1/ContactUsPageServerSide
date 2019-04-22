using Softwave_Server_Side.Dal;
using Softwave_Server_Side.Enums;
using Softwave_Server_Side.Models;
using Softwave_Server_Side.Interfaces;

namespace Softwave_Server_Side.Logic
{
    public class DatabaseFactory
    {
        public static IDatabse<MessageDetails> GetDatabase(ControllerConfigs configurations)
        {
            IDatabse<MessageDetails> databaseType = null;

            switch (configurations.DatabaseType)
            {
                case DatabaseType.SQL:
                    databaseType = new MySQLDB(configurations.Location);
                    break;
                case DatabaseType.FileSystem:
                    databaseType = new FileSystemDB(configurations.Location);
                    break;
                default:
                    databaseType = new MySQLDB(configurations.Location);
                    break;
            }

            return databaseType;
        }
    }
}