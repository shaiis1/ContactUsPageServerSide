using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softwave_Server_Side.Logic
{
    public class RegexStrings
    {
        private static string emailRegex = "";
        private static string phoneNumberRegex = "";

        public static string GetEmailRegex { get { return emailRegex; }
            set { emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9_\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"; }
        }

        public static string GetphoneNumberRegex
        {
            get { return phoneNumberRegex; }
            set { phoneNumberRegex = @"\s*(?:\+?(\d{1,3}))?([-. (]*(\d{3})[-. )]*)?((\d{3})[-. ]*(\d{2,4})(?:[-.x ]*(\d+))?)\s*"; }
        }
    }
}