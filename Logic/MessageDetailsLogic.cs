using System;
using Softwave_Server_Side.Models;
using System.Text.RegularExpressions;
using Softwave_Server_Side.Interfaces;

namespace Softwave_Server_Side.Logic
{
    public class MessageDetailsLogic : IMessageDetailsLogic
    {
        #region Members
        private ControllerConfigs m_configurations;
        #endregion

        #region Constructor
        public MessageDetailsLogic(ControllerConfigs configurations)
        {
            m_configurations = configurations;
        }
        #endregion

        #region Public Methods
        public void CreateMessageDetail(MessageDetails i_details)
        {
            if (!IsValidFields(i_details))
                throw new ArgumentException("Arguments are not valid.");

            using (IDatabse<MessageDetails> database = DatabaseFactory.GetDatabase(m_configurations))
            {
                database.CreateEntity(i_details);
            }
        }
        #endregion

        #region Private Methods
        private bool IsValidFields(MessageDetails i_details)
        {
            if (i_details == null
                || string.IsNullOrEmpty(i_details.m_email)
                || string.IsNullOrEmpty(i_details.m_phoneNumber)
                || string.IsNullOrEmpty(i_details.m_subject)
                || string.IsNullOrEmpty(i_details.m_content)
                || !Regex.Match(i_details.m_phoneNumber, @"\s*(?:\+?(\d{1,3}))?([-. (]*(\d{3})[-. )]*)?((\d{3})[-. ]*(\d{2,4})(?:[-.x ]*(\d+))?)\s*").Success
                || !Regex.Match(i_details.m_email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9_\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").Success) { 
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}