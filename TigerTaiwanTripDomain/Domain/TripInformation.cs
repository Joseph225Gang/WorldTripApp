using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class TripInformation
    {
        public Guid TripId { get; set; }
        public string ImgUrl { get; set; }
        public string TripName { get; set; }
        public decimal Cost { get; set; }
        public string TripDescription { get; set; }
    }
}
