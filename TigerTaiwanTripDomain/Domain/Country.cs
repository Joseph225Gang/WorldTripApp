using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class Country
    {
        Guid id { get; set; }
        List<TripInformation> Trips { get; set; }
    }
}
