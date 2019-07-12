using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
