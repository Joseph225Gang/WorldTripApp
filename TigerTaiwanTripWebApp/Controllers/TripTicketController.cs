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
        WorldTripRepository worldTripRepository;

        public TripTicketController(WorldTripRepository worldTripRepository)
        {
            this.worldTripRepository = worldTripRepository;
        }

        [HttpGet("[action]")]
        public IEnumerable<Ticket> GetRelevantTicket(string tripName)
        {
            return worldTripRepository.GetRelevantTicket(tripName);
        }
    }
}