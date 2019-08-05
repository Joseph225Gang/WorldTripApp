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
    public class EuropeContinentController : ControllerBase
    {
        private readonly ContinentPart europeCountries = ContinentPart.Instance;

        [HttpGet("[action]")]
        public IEnumerable<string> GetEuropeCountries(int countryCode)
        {
            return europeCountries.europe.Countries[(EuropeRegion)countryCode].Select(country => country.CountryName);
        }

        [HttpGet("[action]")]
        public IEnumerable<TripInformation> GetSelectedEuropeTrips(int countryCode, string country)
        {
            return europeCountries.europe.Countries[(EuropeRegion)countryCode].Where(selectCountry => selectCountry.CountryName == country).FirstOrDefault().Trips;
        }
    }
}