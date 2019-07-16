using System;
using System.Collections.Generic;
using System.Text;
using TigerTaiwanTripDomain;

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
                throw new Exception(ex.InnerException.ToString());
            }
        }
    }
}
