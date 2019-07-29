using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class MemberTicket
    {
        public Guid MemberId { get; set; }
        public Member Member { get; set; }

        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
