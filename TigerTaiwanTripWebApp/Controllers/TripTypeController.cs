using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TigerTaiwanTripDomain;
using TigerTaiwanTripWebService;

namespace TigerTaiwanTripWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripTypeController : ControllerBase
    {
        MemberRepository memberRepository;

        public TripTypeController(MemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        [HttpGet("[action]")]
        public IEnumerable<Dictionary<int,string>> GetTotalTripType()
        {
            foreach (string name in Enum.GetNames(typeof(TripType)))
            {
                int value =  (int)Enum.Parse(typeof(TripType), name);
                Dictionary<int, string> tripType = new Dictionary<int, string>();
                tripType.Add(value, name);
                yield return tripType;
            }
        }
    }
}