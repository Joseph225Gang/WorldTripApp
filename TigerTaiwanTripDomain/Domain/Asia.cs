using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class Asia : ContinentInformation
    {
        public Dictionary<AsiaContinent, List<Country>> Countries { get; set; }
    }
}
