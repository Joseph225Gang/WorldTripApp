using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class Country
    {
        public Guid id { get; set; }
        public List<TripInformation> Trips { get; set; }
        public string CountryName { get; set; }
    }
}
