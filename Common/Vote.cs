using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrBAE.Congress.Common
{
    public class Vote
    {
        public Vote(int id, decimal rate, decimal seat)
        {
            Id = id;
            PropVoteRate = rate;
            NumDistrictSeat = seat;
        }
        public int Id { get; set; }
        public decimal NumDistrictSeat { get; set; }
        public decimal PropVoteRate { get; set; }
    }
}
