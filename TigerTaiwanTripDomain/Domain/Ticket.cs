using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public partial class Ticket
    {
        public Guid TicketID { get; set; }
        public DateTime PaymentExpireDay { get; set; }
        public DateTime TravelStrateDate { get; set; }
        public Boolean Payed { get; set; }
        public int PaymentMethodUsed { get; set; }
        public Decimal Amount { get; set; }
        public int TicketType { get; set; }
        public IList<MemberTicket> MemberTickets { get; set; }
    }
}
