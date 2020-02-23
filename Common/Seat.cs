using System;
using System.Collections.Generic;
using System.Text;

namespace DrBAE.Congress.Common
{
    public class Seat
    {
        public Party Party { get; set; } = new Party();
        public Vote Vote { get; set; } = new Vote();

        public bool CanHavePropSeat { get; set; }//비례의석 가능
        public decimal PropVoteRate { get; set; } = 0.0m;//비례 득표율
        public decimal PropSeat { get; set; }
        public decimal PropSeat { get; set; }
        public decimal PropSeat { get; set; }
        public decimal TotalSeat { get; set; }
    }
}
