using System;
using System.Collections.Generic;
using System.Text;

namespace TigerTaiwanTripDomain
{
    public class ContinentPart
    {
        public Asia asia;
        public American american;
        public Europe europe;

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
            korea.Trips = GetKoreaTrip();

            Country china = new Country();
            china.CountryName = "大陸";
            china.Trips = GetChinaTrip();

            List<Country> asisEast = new List<Country>();

            asisEast.Add(japan);
            asisEast.Add(hongKong);
            asisEast.Add(korea);
            asisEast.Add(china);
            asia.Countries.Add(AsiaContinent.East, asisEast);

            Country singapore = new Country();
            singapore.CountryName = "新加坡";
            singapore.Trips = GetSingapore();

            Country maylsis = new Country();
            maylsis.CountryName = "馬來西亞";
            maylsis.Trips = GetMalaysia();

            Country vietnam = new Country();
            vietnam.CountryName = "越南";
            vietnam.Trips = GetVietnamTrip();

            Country thialand = new Country();
            thialand.CountryName = "泰國";
            thialand.Trips = GetThialandTrip();

            List<Country> asiaSouthEast = new List<Country>();

            asiaSouthEast.Add(singapore);
            asiaSouthEast.Add(maylsis);
            asiaSouthEast.Add(thialand);
            asiaSouthEast.Add(vietnam);
            asia.Countries.Add(AsiaContinent.EastSouth, asiaSouthEast);

            Country india = new Country();
            india.CountryName = "印度";
            india.Trips = GetIndiaTrip();
            

            List<Country> asiaSouth = new List<Country>();
            asiaSouth.Add(india);

            asia.Countries.Add(AsiaContinent.South, asiaSouth);

            american = new American()
            {
                Id = Guid.NewGuid(),
                ContinentName = "美洲",
                Continents = Continent.American,
                Countries = new List<Country>()
            };

            Country unitedState = new Country();
            unitedState.CountryName = "美國";
            unitedState.Trips = GetAmericanTrip();

            Country canada = new Country();
            canada.CountryName = "加拿大";
            canada.Trips = GetCanadaTrip();

            american.Countries.Add(unitedState);
            american.Countries.Add(canada);

            europe = new Europe()
            {
                Id = Guid.NewGuid(),
                ContinentName = "歐洲",
                Continents = Continent.Europe,
                Countries = new Dictionary<EuropeRegion, List<Country>>()
            };

            Country england = new Country();
            england.CountryName = "英國";
            england.Trips = GetEnglandTrip();

            Country france = new Country();
            france.CountryName = "法國";
            france.Trips = GetFranceTrip();

            Country german = new Country();
            german.CountryName = "德國";
            german.Trips = GetGermanTrip();

            List<Country> europeWest = new List<Country>();
            europeWest.Add(england);
            europeWest.Add(france);
            europeWest.Add(german);

            europe.Countries.Add(EuropeRegion.West, europeWest);

            Country italy = new Country();
            italy.CountryName = "義大利";
            italy.Trips = GetItalyTrip();

            List<Country> europeSouth = new List<Country>();
            europeSouth.Add(italy);

            europe.Countries.Add(EuropeRegion.South, europeSouth);
        }

        private List<TripInformation> GetChinaTrip()
        {
            var ChinaTrip = new List<TripInformation>();
            ChinaTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "上海3日行",
                ImgUrl = "http://pic.lvmama.com/uploads/pc/place2/2017-12-05/9182dbbb-32b9-4ade-b28f-8e4353fd6e77.jpg"
            });

            ChinaTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "北京3日行",
                ImgUrl = "http://pic12.nipic.com/20110117/5261625_153143624108_2.jpg"
            });
            
            ChinaTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "福建3日行",
                ImgUrl = "http://img1.3lian.com/img013/v2/91/d/81.jpg"
            });

            return ChinaTrip;
        }

        private List<TripInformation> GetKoreaTrip()
        {
            var KoreaTrip = new List<TripInformation>();
            KoreaTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "首爾2日行",
                ImgUrl = "https://www.hdwallpaper.nu/wp-content/uploads/2015/04/464629385-seoul.jpg"
            });
            
            return KoreaTrip;
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

        private List<TripInformation> GetSingapore()
        {
            var singapore = new List<TripInformation>();
            singapore.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "新加坡1日行",
                ImgUrl = "http://file.loyouyou.com/UpLoadFiles/2011/1/27/2011127000827145328.jpg"
            });

            return singapore;
        }

        private List<TripInformation> GetVietnamTrip()
        {
            var vietnamtrip = new List<TripInformation>();
            vietnamtrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "越南5日遊",
                ImgUrl = "https://www.isaiah-vietnam.com/wp-content/uploads/2018/08/bigstock-203139388.jpg"
            });

            return vietnamtrip;
        }

        private List<TripInformation> GetThialandTrip()
        {
            var thialndTrip = new List<TripInformation>();
            thialndTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "曼谷2日遊",
                ImgUrl = "https://farm4.staticflickr.com/5594/14476045951_dcf5749df6_b.jpg"
            });

            return thialndTrip;
        }

        private List<TripInformation> GetMalaysia()
        {
            var malaysia = new List<TripInformation>();
            malaysia.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "馬來西亞4日遊",
                ImgUrl = "https://www.hdwallpaper.nu/wp-content/uploads/2015/04/398678.jpg"
            });

            return malaysia;
        }

        private List<TripInformation> GetIndiaTrip()
        {
            var indiaTrip = new List<TripInformation>();

            indiaTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "印度5日遊",
                ImgUrl = "http://p3-q.mafengwo.net/s9/M00/B8/B9/wKgBs1ZAZWeAcsIOAARB-hfz4iY86.jpeg"
            });

            return indiaTrip;
        }

        private List<TripInformation> GetAmericanTrip()
        {
            var americaTrip = new List<TripInformation>();

            americaTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "美國一周遊",
                ImgUrl = "https://tse4.mm.bing.net/th?id=OIP.CFkIgsJz6j6ij38c7BtP-AHaE8&pid=Api&P=0&w=247&h=166"
            });

            return americaTrip;
        }

        private List<TripInformation> GetCanadaTrip()
        {
            var candaTrip = new List<TripInformation>();

            candaTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "加拿大一周遊",
                ImgUrl = "https://tse3.mm.bing.net/th?id=OIP.eqByGyZpc_gGqyhomO9hFgHaE8&pid=Api&P=0&w=243&h=163"
            });

            return candaTrip;
        }

        private List<TripInformation> GetEnglandTrip()
        {
            var englandTrip = new List<TripInformation>();

            englandTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "英國5日行",
                ImgUrl = "https://cw1.tw/CW/images/article/201706/article-5939dee0c9d53.jpg"
            });

            return englandTrip;
        }

        private List<TripInformation> GetFranceTrip()
        {
            var franceTrip = new List<TripInformation>();

            franceTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "法國5日行",
                ImgUrl = "https://tse1.mm.bing.net/th?id=OIP.wkixqDkS_-hqlh0YaD4dcwHaEK&pid=Api&P=0&w=279&h=158"
            });

            return franceTrip;
        }

        private List<TripInformation> GetGermanTrip()
        {
            var germanTrip = new List<TripInformation>();

            germanTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "德國5日行",
                ImgUrl = "https://tse3.mm.bing.net/th?id=OIP.RH48X7IadB53E8gG-rHzIgHaE7&pid=Api&P=0&w=264&h=177"
            });

            return germanTrip;
        }

        private List<TripInformation> GetItalyTrip()
        {
            var italyTrip = new List<TripInformation>();

            italyTrip.Add(new TripInformation()
            {
                TripId = Guid.NewGuid(),
                TripName = "義大利5日行",
                ImgUrl = "https://i.ytimg.com/vi/W95BlJGXUOc/maxresdefault.jpg"
            });

            return italyTrip;
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
