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
            PartyVoteRate = rate;
            DistrictSeat = seat;
        }
        public Vote((int id, decimal rate, decimal seat) v) : this(v.id, v.rate, v.seat) { }
        public int Id { get; set; }
        public decimal PartyVoteRate { get; set; }
        public decimal DistrictSeat { get; set; }

        public override string ToString() => Pack();

        public string Pack() => $"{Id,2} {PartyVoteRate,5:N2} {DistrictSeat,3}";
        public static Vote Parse(string packed)
        {
            var values = packed.Split(' ').Select(x => decimal.Parse(x)).ToArray();
            return new Vote((int)values[0], values[1], values[2]);
        }
    }
}
