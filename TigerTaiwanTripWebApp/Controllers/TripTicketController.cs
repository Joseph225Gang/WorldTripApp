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
    public class TripTicketController : ControllerBase
    {
        MemberRepository memberRepository;

        public TripTicketController(MemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        [HttpGet("[action]")]
        public IEnumerable<Ticket> GetRelevantTicket(string tripName)
        {
            return memberRepository.GetRelevantTicket(tripName);
        }
    }
}