using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TigerTaiwanTripDomain;
using TigerTaiwanTripWebService;

namespace TigerTaiwanTripWebTest
{
    [TestClass]
    public class MemberTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Ticket ticket = new Ticket()
            {
                TicketID = Guid.NewGuid(),
                Amount = 10000,
                PaymentExpireDay = DateTime.Now,
                TravelStrateDate = DateTime.Now,
                TicketType = TicketType.Adult,
            };

            Member member = new Member()
            {
                Id = Guid.NewGuid(),
                BirthDay = DateTime.Now,
                Email = "aaa@mail.com",
                MobilePhone = "999",
                Name = "Josh",
                PassWord = "111"
            };

            member.MemberTickets = new List<MemberTicket>
            {
                new MemberTicket
                {
                    Member = member,
                    Ticket = ticket
                }
            };
            
        }
    }
}
