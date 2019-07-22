using System;
using System.Collections.Generic;
using System.Text;
using TigerTaiwanTripDomain;
using System.Linq;

namespace TigerTaiwanTripWebService
{
    public  class MemberRepository
    {
        private MemberContext db;

        public MemberRepository(MemberContext db)
        {
            this.db = db;
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
