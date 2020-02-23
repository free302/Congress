using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrBAE.Congress.Common
{
    public class Vote
    {
        public Vote() { }
        public Vote(int id, decimal rate, decimal seat)
        {
            Id = id;
            PropVoteRate = rate;
            NumDistrictSeat = seat;
        }
        public Vote((int id, decimal rate, decimal seat) v) : this(v.id, v.rate, v.seat) { }
        public int Id { get; set; }
        public decimal NumDistrictSeat { get; set; }
        public decimal PropVoteRate { get; set; }

        public override string ToString() => Pack();

        public string Pack() => $"{Id}:{PropVoteRate}:{NumDistrictSeat}";
        public static Vote Parse(string packed)
        {
            var values = packed.Split(':').Select(x => decimal.Parse(x)).ToArray();
            return new Vote((int)values[0], values[1], values[2]);
        }
    }
}
