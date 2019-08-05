using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class TaiwanUtility
    {
        public Taiwan taiwan;
        private static TaiwanUtility _instance;

        private TaiwanUtility()
        {
            taiwan = new Taiwan()
            {
                Cities = new Dictionary<TaiwanRegion, List<Country>>()
            };

            Country Taipei = new Country();
            Taipei.CountryName = "台北市";
            Taipei.Trips = GetTaipeiTrip();
            Taipei.id = Guid.NewGuid();

            Country TaiwanMiddle = new Country();
            TaiwanMiddle.CountryName = "台中市";
            TaiwanMiddle.Trips = GetTaiwanMiddleTrip();
            TaiwanMiddle.id = Guid.NewGuid();

            Country TaiwanSouth = new Country();
            TaiwanSouth.CountryName = "墾丁";
            TaiwanSouth.Trips = GetTaiwanSouthTrip();
            TaiwanSouth.id = Guid.NewGuid();

            List<Country> taiwanNorth = new List<Country>();
            taiwanNorth.Add(Taipei);

            List<Country> taiwanMiddle = new List<Country>();
            taiwanMiddle.Add(TaiwanMiddle);

            List<Country> taiwanSouth = new List<Country>();
            taiwanSouth.Add(TaiwanSouth);

            taiwan.Cities.Add(TaiwanRegion.North, taiwanNorth);
            taiwan.Cities.Add(TaiwanRegion.Middle, taiwanMiddle);
            taiwan.Cities.Add(TaiwanRegion.South, taiwanSouth);
        }

        private List<TripInformation> GetTaipeiTrip()
        {
            var taipei = new List<TripInformation>();
            taipei.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "台北1日行",
                ImgUrl = "http://web.ntnu.edu.tw/~498231299/homepage/homepage_Chance/picture/p1.jpg"
            });

            return taipei;
        }

        private List<TripInformation> GetTaiwanMiddleTrip()
        {
            var taiwanMiddle = new List<TripInformation>();
            taiwanMiddle.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "台中1日行",
                ImgUrl = "https://tse2.mm.bing.net/th?id=OIP.I7P-dF5proaz3xyTRWq7cwEsCo&pid=Api&P=0&w=322&h=182"
            });

            return taiwanMiddle;
        }

        private List<TripInformation> GetTaiwanSouthTrip()
        {
            var taiwanSouth = new List<TripInformation>();
            taiwanSouth.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "墾丁1日行",
                ImgUrl = "http://www.ktchateau.com.tw/upload/fac_b/51e9d7e00409be658052c97f865c8460.jpg"
            });

            return taiwanSouth;
        }

        public static TaiwanUtility Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TaiwanUtility();
                return _instance;
            }
        }
    }
}
