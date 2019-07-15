using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class ContinentInformation
    {
        public Guid Id { get; set; }
        public string ContinentName { get; set; }
        public Continent Continents {get;set;}
    }
}
