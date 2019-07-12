using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class ContinentPart
    {
        private readonly string[] EastSouthAsia = {"馬來西亞","新加玻","越南","泰國","緬甸" };
        private readonly string[] NothernAsia = { "日本", "韓國", "香港", "大陸"};
        private readonly string[] SouthAsia = { "印度", "巴基斯坦"};

        public Dictionary<AsiaContinent, string[]> ContinentCode = new Dictionary<AsiaContinent, string[]>();
        public Dictionary<AsiaContinent, Dictionary<int, List<TripInformation>>> ContinentTripInformation = new Dictionary<AsiaContinent, Dictionary<int, List<TripInformation>>>();
        private static ContinentPart _instance;

        private ContinentPart() {
            ContinentCode.Add(AsiaContinent.EastSouth, EastSouthAsia);
            ContinentCode.Add(AsiaContinent.North, NothernAsia);
            ContinentCode.Add(AsiaContinent.South, SouthAsia);

            Dictionary<int, List<TripInformation>> northAsiaTrip = new Dictionary<int, List<TripInformation>>();
            northAsiaTrip.Add(0, GetJapanTrip());
            northAsiaTrip.Add(2, GeHongKongTrip());
            ContinentTripInformation.Add(AsiaContinent.North, northAsiaTrip);
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
