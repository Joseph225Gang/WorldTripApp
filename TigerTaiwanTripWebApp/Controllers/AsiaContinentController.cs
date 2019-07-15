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
        private readonly ContinentPart asiaCountries = ContinentPart.Instance;

        
        [HttpGet("[action]")]
        public IEnumerable<string> GetAsiaCountries(int countryCode)
        {
            return asiaCountries.asia.Countries[(AsiaContinent)countryCode].Select(country => country.CountryName);
        }

        [HttpGet("[action]")]
        public IEnumerable<TripInformation> GetSelectedAsiaTrips(int countryCode, string country)
        {
            return asiaCountries.asia.Countries[(AsiaContinent)countryCode].Where(selectCountry => selectCountry.CountryName == country).FirstOrDefault().Trips;
        }
    }
}