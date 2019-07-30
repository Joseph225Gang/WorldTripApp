using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string MemberName { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TripName { get; set; }
        public int AdultTicket { get; set; }
        public int ChildTicket { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
