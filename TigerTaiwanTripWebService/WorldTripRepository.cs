using System;
using System.Collections.Generic;
using System.Text;
using TigerTaiwanTripDomain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TigerTaiwanTripWebService
{
    public  class WorldTripRepository
    {
        private WorldTripContext db;

        public WorldTripRepository(WorldTripContext db)
        {
            this.db = db;
        }

        public void AddTransaction(Transaction transaction)
        {
            this.db.Transactions.Add(transaction);
            this.db.SaveChanges();
        }

        public IEnumerable<Transaction> ShowTransactionInformation(string userName)
        {
            return db.Transactions.Where(i => i.MemberName == userName);
        }

        public void AddDefaultTicket()
        {
            //Ticket japanA = new Ticket();
            //japanA.TicketID = Guid.NewGuid();
            //japanA.TicketType = TicketType.Adult;
            //japanA.TravelStrateDate = DateTime.Now;
            //japanA.PaymentExpireDay = DateTime.Now;
            //japanA.Amount = 25000;
            //japanA.TripName = "東京3日行";

            //Ticket japanB = new Ticket();
            //japanB.TicketID = Guid.NewGuid();
            //japanB.TicketType = TicketType.Child;
            //japanB.TravelStrateDate = DateTime.Now;
            //japanB.PaymentExpireDay = DateTime.Now;
            //japanB.Amount = 25000;
            //japanB.TripName = "東京3日行";

            //db.Tickets.Add(japanA);
            //db.Tickets.Add(japanB);
            //db.SaveChanges();

            Ticket taipeiA = new Ticket();
            taipeiA.TicketID = Guid.NewGuid();
            taipeiA.TicketType = TicketType.Adult;
            taipeiA.TravelStrateDate = DateTime.Now;
            taipeiA.PaymentExpireDay = DateTime.Now;
            taipeiA.Amount = 2000;
            taipeiA.TripName = "台北1日行";

            Ticket taipeiB = new Ticket();
            taipeiB.TicketID = Guid.NewGuid();
            taipeiB.TicketType = TicketType.Child;
            taipeiB.TravelStrateDate = DateTime.Now;
            taipeiB.PaymentExpireDay = DateTime.Now;
            taipeiB.Amount = 1500;
            taipeiB.TripName = "台北1日行";

            Ticket twMiddle = new Ticket();
            twMiddle.TicketID = Guid.NewGuid();
            twMiddle.TicketType = TicketType.Adult;
            twMiddle.TravelStrateDate = DateTime.Now;
            twMiddle.PaymentExpireDay = DateTime.Now;
            twMiddle.Amount = 2000;
            twMiddle.TripName = "台中1日行";

            Ticket twMiddle1 = new Ticket();
            twMiddle1.TicketID = Guid.NewGuid();
            twMiddle1.TicketType = TicketType.Child;
            twMiddle1.TravelStrateDate = DateTime.Now;
            twMiddle1.PaymentExpireDay = DateTime.Now;
            twMiddle1.Amount = 1500;
            twMiddle1.TripName = "台中1日行";

            Ticket twSouth = new Ticket();
            twSouth.TicketID = Guid.NewGuid();
            twSouth.TicketType = TicketType.Adult;
            twSouth.TravelStrateDate = DateTime.Now;
            twSouth.PaymentExpireDay = DateTime.Now;
            twSouth.Amount = 2000;
            twSouth.TripName = "墾丁1日行";

            Ticket twSouth1 = new Ticket();
            twSouth1.TicketID = Guid.NewGuid();
            twSouth1.TicketType = TicketType.Child;
            twSouth1.TravelStrateDate = DateTime.Now;
            twSouth1.PaymentExpireDay = DateTime.Now;
            twSouth1.Amount = 1500;
            twSouth1.TripName = "墾丁1日行";

            db.Tickets.Add(taipeiA);
            db.Tickets.Add(taipeiB);
            db.Tickets.Add(twMiddle);
            db.Tickets.Add(twMiddle1);
            db.Tickets.Add(twSouth);
            db.Tickets.Add(twSouth1);

            db.SaveChanges();
        }

        public IEnumerable<Ticket> GetRelevantTicket(string tripName)
        {
            return db.Tickets.Where(i => i.TripName == tripName);
        }

        public void Create(Member member)
        {
            try
            {
                db.Members.Add(member);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public IEnumerable<Member> ShowAllMember()
        {
            return db.Members;
        }

        public string GetLoginUser(string userName, string password)
        {
            Member member = db.Members.Where(u => u.Name == userName && u.PassWord == password).FirstOrDefault();
            if (member != null)
                return member.Name;
            else
                return "";
        }
        

        public Member GetCurrentUserInfo(string userName)
        {
            Member member = db.Members.Where(u => u.Name == userName).FirstOrDefault();
            return member;
        }

        public void Update(Member member)
        {
            db.Members.Update(member);
            db.SaveChanges();
        }
    }
}
