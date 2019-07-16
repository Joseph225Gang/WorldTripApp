using System;
using System.Collections.Generic;
using System.Text;
using TigerTaiwanTripDomain;

namespace TigerTaiwanTripDomain
{
    public partial class Member
    {
        public StringBuilder Validation(dynamic member)
        {
            StringBuilder errorMessage = new StringBuilder();

            if (!DateTimeValidation.Validate((string)member.BirthDay))
                errorMessage.Append("出生年月日格式不對\n");
            if(!StringValidation.StringValidate((string)member.MobilePhone,10))
                errorMessage.Append("聯絡電話長度需為10\n");
            if (!StringValidation.StringMinLengthValidate((string)member.Password, 10))
                errorMessage.Append("密碼長度至少為10\n");

            return errorMessage;
        }
    }
}
