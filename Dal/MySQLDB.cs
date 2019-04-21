using MySql.Data.MySqlClient;
using Softwave_Server_Side.Models;

namespace Softwave_Server_Side.Dal
{
    public class MySQLDB : IDatabse<MessageDetails>
    {
        #region Members
        private string m_connectionString = string.Empty;
        private string m_tableName = "messagedetails";
        private long id ;

        public MySqlConnection Connection { get; private set; }
        #endregion

        #region Constructor
        public MySQLDB()
        {
            m_connectionString = string.Empty;
        }

        public MySQLDB(string connectionString)
        {
            m_connectionString = connectionString;
        }
        #endregion

        #region Public Methods
        public void CreateEntity(MessageDetails entity)
        {
            string query = string.Format("INSERT INTO {0} (email, phoneNumber, subject, content) VALUES(\"{1}\", \"{2}\", \"{3}\", \"{4}\")", m_tableName, entity.m_email, entity.m_phoneNumber, entity.m_subject, entity.m_content);

            if (IsConnect() == true)
            {
                
                MySqlCommand cmd = new MySqlCommand(query, Connection);
                cmd.ExecuteNonQuery();
                
            }
        }

        public void Dispose()
        {
            Connection.Close();
        }
        #endregion

        #region Private Methods
        private bool IsConnect()
        {
            if (Connection == null)
            {
                Connection = new MySqlConnection(m_connectionString);
                Connection.Open();
            }

            return true;
        }
        #endregion
    }
}