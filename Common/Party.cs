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
        
        public bool CanHaveVoteRate { get; set; }//정당~무소속 구분

        /// <summary>
        /// 지역구 없는 정당 총합 - 득표율 != 0, 비례좌석 0
        /// </summary>
        public static Party EtcParty = new Party(98, "기타")
        { CanHaveVoteRate = true, CanHavePropSeat = false };

        /// <summary>
        /// 무소속 - 득표율 0, 비례좌석 0
        /// </summary>
        public static Party IndiParty = new Party(99, "무소속")//무소속
        { CanHaveVoteRate = false, CanHavePropSeat = false };

        public override string ToString() => $"{Id}:{Name}";
    }
}
