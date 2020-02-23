using System;
using System.Collections.Generic;
using System.Text;

namespace DrBAE.Congress.Common
{
    /// <summary>
    /// 정당
    /// </summary>
    public class Party
    {
        public Party() { }
        public Party(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Party((int id, string name) v) : this(v.id, v.name) { }

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal NumDistrictSeat { get; set; }//지역구 의석수
        public decimal VoteRate { get; set; } = 0.0m;//선거 득표율
        public bool CanHavePropSeat { get; set; }//비례의석 가능
        public decimal PropVoteRate { get; set; } = 0.0m;//비례 득표율
        public decimal NumPropSeat { get; set; }
        public bool CanHaveVoteRate { get; set; }//정당~무소속 구분

        /// <summary>
        /// 지역구 없는 정당 총합 - 득표율 != 0, 비례좌석 0
        /// </summary>
        public static Party EtcParty = new Party(99, "기타")
        { CanHaveVoteRate = true, CanHavePropSeat = false };

        /// <summary>
        /// 무소속 - 득표율 0, 비례좌석 0
        /// </summary>
        public static Party IndiParty = new Party(0, "무소속")//무소속
        { CanHaveVoteRate = false, CanHavePropSeat = false };

        public override string ToString() => $"{Id}:{Name}";
    }
}
