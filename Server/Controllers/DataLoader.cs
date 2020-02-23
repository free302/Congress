using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrBAE.Congress.Common;
using DrBAE.Congress.Driver;

namespace DrBAE.Congress.Server.Controllers
{
    public class DataLoader
    {
        private static readonly (int, decimal rate, decimal seat)[] _votes = new[]
        {
            (0, 0m,20),
            (1, 40.40m,116m), (2, 32.10m,91m), (3, 4.10m,7m),(4, 3.80m,8m),(5, 4.40m,2m),
            (6, 1.70m,2m), (7, 1.10m,3m), (8, 1.0m,1m), (9, 1.5m,3m),
            (int.MaxValue, 9.9m,0)
        };
        internal static Vote[] LoadVote()
        {
            //return _votes.Select(x => new Vote(x)).ToArray();
            var driver = new DriverLogic();
            return driver.GetVoteData(false);
        }

        private static readonly (int, string)[] _parties = new[]
        {
            (0, "무소속"),(1, "더불어민주당"),(2, "미래통합당"),(3, "민주통합당"),(4, "정의당"),(5, "국민의당"),
            (6, "우리공화당"),(7, "민중당"),(8, "친박신당"),(99, "기타")
        };
        internal static Party[] LoadParty()
        {
            //return _parties.Select(x => new Party(x)).ToArray();
            var driver = new DriverLogic();
            return driver.GetPartyData(false);
        }
    }
}
