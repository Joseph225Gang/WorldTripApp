using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TigerTaiwanTripDomain;

namespace TigerTaiwanTripWebService
{
    public class MemberContext : DbContext
    {

        public MemberContext(DbContextOptions<MemberContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}
