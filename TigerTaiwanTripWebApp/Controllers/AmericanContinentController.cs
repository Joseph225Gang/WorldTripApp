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
    public class AmericanContinentController : ControllerBase
    {
        private readonly ContinentPart americanCountries = ContinentPart.Instance;


        [HttpGet("[action]")]
        public IEnumerable<string> GetAmericanCountries()
        {
            return americanCountries.american.Countries.Select(country => country.CountryName); ;
        }

        [HttpGet("[action]")]
        public IEnumerable<TripInformation> GetSelectedAmericanTrips(string country)
        {
            return americanCountries.american.Countries.Where(selectCountry => selectCountry.CountryName == country).FirstOrDefault().Trips;
        }
    }
}