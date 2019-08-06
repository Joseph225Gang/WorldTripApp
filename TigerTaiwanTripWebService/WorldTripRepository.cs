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
