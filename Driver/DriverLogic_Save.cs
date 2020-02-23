using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DrBAE.Congress.Common;

namespace DrBAE.Congress.Driver
{
    public partial class DriverLogic
    {
        public void SaveParty(Party[] parties, bool toServer = false)
        {
            var dic = GetPartyData(toServer).ToDictionary(x => x.Id);
            for (int i = 0; i < parties.Length; i++) dic[parties[i].Id] = parties[i];

            if (toServer)
            {
                var text = JsonSerializer.Serialize(dic.Values.ToArray(), new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(_partyFile, text);
            }
            else
            {
                var bytes = JsonSerializer.SerializeToUtf8Bytes(dic.Values.ToArray());
                throw new NotImplementedException();
            }
        }

        public void SaveVote(Vote[] votes, bool toServer = false)
        {
            var dic = GetVoteData(toServer).ToDictionary(x => x.Id);
            for (int i = 0; i < votes.Length; i++) dic[votes[i].Id] = votes[i];

            if (toServer)
            {
                var text = JsonSerializer.Serialize(dic.Values.ToArray(), new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(_voteFile, text);
            }
            else
            {
                var bytes = JsonSerializer.SerializeToUtf8Bytes(dic.Values.ToArray());
                throw new NotImplementedException();
            }
        }

    }
}
