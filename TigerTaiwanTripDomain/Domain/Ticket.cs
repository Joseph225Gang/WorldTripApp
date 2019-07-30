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
        public Decimal Amount { get; set; }
        public TicketType TicketType { get; set; }
        public string TripName { get; set; }
        public IList<MemberTicket> MemberTickets { get; set; }
    }
}
