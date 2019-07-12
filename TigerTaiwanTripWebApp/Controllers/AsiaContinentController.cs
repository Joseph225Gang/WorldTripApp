using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TigerTaiwanTripDomain;

namespace TigerTaiwanTripWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsiaContinentController : ControllerBase
    {
        [HttpGet("[action]")]
        public IEnumerable<string> GetAsiaCountries(int countryCode)
        {
            ContinentPart asiaCountries = ContinentPart.Instance;
            return asiaCountries.ContinentCode[(AsiaContinent)countryCode];

        }

        [HttpGet("[action]")]
        public IEnumerable<TripInformation> GetSelectedAsiaTrips(int countryCode, string country)
        {
            ContinentPart asiaCountries = ContinentPart.Instance;
            var asiaRegion = asiaCountries.ContinentTripInformation[(AsiaContinent)countryCode];
            if (country.Equals("日本"))
                return asiaRegion[0];
            else if (country.Equals("香港"))
                return asiaRegion[2];
            else
                return new List<TripInformation>();

        }
    }
}