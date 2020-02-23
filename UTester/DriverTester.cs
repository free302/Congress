using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DrBAE.Congress.Driver;

namespace UTester
{
    /// <summary>
    /// class for testing Driver project
    /// </summary>
    public class DriverTester
    {
        [Fact]
        public void run()
        {
            var driver = new DriverLogic();
            var votes = driver.GetVoteData(true);


        }
    }
}
