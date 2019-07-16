using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public static class DateTimeValidation
    {
        public static Boolean Validate(string time)
        {
            if (DateTime.TryParse(time, out DateTime tempBirthDay))
                return true;
            else
                return false;
        }
    }
}
