using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class Europe : ContinentInformation
    {
        public Dictionary<EuropeRegion, List<Country>> Countries { get; set; }
    }
}
