using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class ContinentPart
    {
        public Asia asia;

        private static ContinentPart _instance;



        private ContinentPart() {

            asia = new Asia()
            {
                Id = Guid.NewGuid(),
                ContinentName = "亞洲",
                Continents = Continent.Asia,
                Countries = new Dictionary<AsiaContinent, List<Country>>()
            };

            Country japan = new Country();
            japan.CountryName = "日本";
            japan.Trips = GetJapanTrip();
            japan.id = Guid.NewGuid();

            Country hongKong = new Country();
            hongKong.CountryName = "香港";
            hongKong.Trips = GeHongKongTrip();

            Country korea = new Country();
            korea.CountryName = "韓國";
            korea.Trips = new List<TripInformation>();

            Country china = new Country();
            china.CountryName = "大陸";
            china.Trips = new List<TripInformation>();

            List<Country> asisNorth = new List<Country>();

            asisNorth.Add(japan);
            asisNorth.Add(hongKong);
            asisNorth.Add(korea);
            asisNorth.Add(china);
            asia.Countries.Add(AsiaContinent.North, asisNorth);

            Country singapore = new Country();
            singapore.CountryName = "新加坡";
            singapore.Trips = new List<TripInformation>();

            Country maylsis = new Country();
            maylsis.CountryName = "馬來西亞";
            maylsis.Trips = new List<TripInformation>();

            Country vietnam = new Country();
            vietnam.CountryName = "越南";
            vietnam.Trips = new List<TripInformation>();

            Country southEastCountry1 = new Country();
            southEastCountry1.CountryName = "緬甸";
            southEastCountry1.Trips = new List<TripInformation>();

            Country thialand = new Country();
            thialand.CountryName = "泰國";
            thialand.Trips = new List<TripInformation>();

            List<Country> asiaSouthEast = new List<Country>();

            asiaSouthEast.Add(singapore);
            asiaSouthEast.Add(maylsis);
            asiaSouthEast.Add(thialand);
            asiaSouthEast.Add(vietnam);
            asiaSouthEast.Add(southEastCountry1);
            asia.Countries.Add(AsiaContinent.EastSouth, asiaSouthEast);

            Country india = new Country();
            india.CountryName = "印度";
            india.Trips = new List<TripInformation>();

            Country southAsia = new Country();
            southAsia.CountryName = "巴基斯坦";
            southAsia.Trips = new List<TripInformation>();

            List<Country> asiaSouth = new List<Country>();
            asiaSouth.Add(india);
            asiaSouth.Add(southAsia);

            asia.Countries.Add(AsiaContinent.South, asiaSouth);
        }

        private List<TripInformation> GetJapanTrip()
        {
            var JapnTrip = new List<TripInformation>();
            JapnTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "東京3日行",
                Cost = 25000,
                ImgUrl = "https://res.klook.com/images/fl_lossy.progressive,q_65/c_fill,w_1295,h_720,f_auto/w_80,x_15,y_15,g_south_west,l_klook_water/activities/wa2omr78cqzw62tpwath/%E6%9D%B1%E4%BA%AC%E9%90%B5%E5%A1%94%E5%A4%A7%E5%B1%95%E6%9C%9B%E5%8F%B0%E9%96%80%E7%A5%A8(150m).jpg"
            });

            JapnTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "大阪旅遊",
                Cost = 20000,
                ImgUrl = "https://4.bp.blogspot.com/-dd3T2wTk768/WUyLBx_IMuI/AAAAAAAAR-I/DM7tGUZP1H8iMC7udZgyP2k-tiUgdwfLgCEwYBhgL/s1600/Fotolia_81096041_Subscription_Yearly_M.jpg"
            });

            JapnTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "關島兩日遊",
                Cost = 15000,
                ImgUrl = "https://blog.hotelscombined.com.tw/wp-content/uploads/2019/03/F2-1.jpg"
            });

            return JapnTrip;
        }

        private List<TripInformation> GeHongKongTrip()
        {
            var HongKongTrip = new List<TripInformation>();

            HongKongTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "香港兩日遊",
                Cost = 12000,
                ImgUrl = "https://partnernet.hktb.com/filemanager/en/content_17/123.jpg"
            });

            return HongKongTrip;
        }

        public static ContinentPart Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ContinentPart();
                return _instance;
            }
        }
    }
}
