using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public static class StringValidation
    {
        public static Boolean StringMinLengthValidate(string member, int strLength)
        {
            if (member.Length < strLength)
                return false;
            else
                return true;
        }

        public static Boolean StringMaxhValidate(string member, int strLength)
        {
            if (member.Length > strLength)
                return false;
            else
                return true;
        }

        public static Boolean StringValidate(string member, int strLength)
        {
            if (member.Length != strLength)
                return false;
            else
                return true;
        }
    }
}
