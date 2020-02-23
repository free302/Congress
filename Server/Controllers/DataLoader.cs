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
        internal static Vote[] LoadVote()
        {
            var driver = new DriverLogic();
            return driver.GetVoteData(false);
        }

        internal static Party[] LoadParty()
        {
            var driver = new DriverLogic();
            return driver.GetPartyData(false);
        }
    }
}
