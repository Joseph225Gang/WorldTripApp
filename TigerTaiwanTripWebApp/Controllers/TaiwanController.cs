using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TigerTaiwanTripDomain;

namespace TigerTaiwanTripWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiwanController : ControllerBase
    {
        private readonly TaiwanUtility taiwan = TaiwanUtility.Instance;


        [HttpGet("[action]")]
        public IEnumerable<string> GetTaiwanRegion(int countryCode)
        {
            return taiwan.taiwan.Cities[(TaiwanRegion)countryCode].Select(country => country.CountryName);
        }

        [HttpGet("[action]")]
        public IEnumerable<TripInformation> GetTaiwanRegionTrips(int countryCode, string country)
        {
            return taiwan.taiwan.Cities[(TaiwanRegion)countryCode].Where(selectCountry => selectCountry.CountryName == country).FirstOrDefault().Trips;
        }
    }
}