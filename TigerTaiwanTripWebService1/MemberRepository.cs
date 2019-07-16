using System;
using System.Collections.Generic;
using System.Text;
using TigerTaiwanTripDomain;

namespace TigerTaiwanTripWebService
{
    public class MemberRepository
    {
        private MemberContext db = new MemberContext();

        public void Create(Member member)
        {
            try
            {
                db.Member.Add(member);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }
        }
    }
}
