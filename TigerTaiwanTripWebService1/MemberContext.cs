using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TigerTaiwanTripDomain;

namespace TigerTaiwanTripWebService
{
    public class MemberContext : DbContext
    {
        public MemberContext() : base("MemberContext")
        {
            
        }

        public DbSet<Member> Member { get; set; }
    }
}
