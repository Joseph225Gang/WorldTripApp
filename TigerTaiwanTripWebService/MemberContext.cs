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
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<MemberTicket> MemberTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MemberTicket>().HasKey(mt => new { mt.MemberId, mt.TicketId });
        }
    }
}
