using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class American : ContinentInformation
    {
        public Dictionary<AmericanRegion, List<Country>> Countries { get; set; }
    }
}
