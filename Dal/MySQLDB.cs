using MySql.Data.MySqlClient;
using Softwave_Server_Side.Models;
using Softwave_Server_Side.Interfaces;

namespace Softwave_Server_Side.Dal
{
    public class MySQLDB : IDatabse<MessageDetails>
    {
        #region Members
        private string m_connectionString = string.Empty;
        private string m_tableName = "messagedetails";

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
            string query = string.Format("INSERT INTO {0} (email, phoneNumber, subject, content) VALUES(?Email, ?Phone, ?Subject, ?Content)", m_tableName);

            if (IsConnect() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, Connection);
                cmd.Parameters.Add("?Email", MySqlDbType.VarChar).Value = entity.m_email;
                cmd.Parameters.Add("?Phone", MySqlDbType.VarChar).Value = entity.m_phoneNumber;
                cmd.Parameters.Add("?Subject", MySqlDbType.VarChar).Value = entity.m_subject;
                cmd.Parameters.Add("?Content", MySqlDbType.VarChar).Value = entity.m_content;
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