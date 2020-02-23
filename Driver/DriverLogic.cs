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
    public partial class DriverLogic : IDriver
    {
        const string _partyFile = "PartyData.json";
        const string _partyUrl = "https://localhost:44318/party";

        public Party[] GetPartyData(bool fromServer) => fromServer ? loadPartyFromWeb() : loadPartyFromFile();

        Party[] loadPartyFromFile()
        {
            try
            {
                return JsonSerializer.Deserialize<Party[]>(File.ReadAllText(_partyFile));
            }
            catch
            {
                return new Party[0];
            }
        }

        Party[] loadPartyFromWeb()
        {
            var client = new HttpClient();
            var response = client.GetAsync(_partyUrl, HttpCompletionOption.ResponseContentRead).Result;
            if (response.IsSuccessStatusCode)
            {
                var bytes = response.Content.ReadAsByteArrayAsync().Result;
                return JsonSerializer.Deserialize<Party[]>(bytes);
            }
            else return new Party[0];
        }

        const string _voteFile = "VoteData.json";
        const string _voteUrl = "https://localhost:44318/vote";

        public Vote[] GetVoteData(bool fromServer) => fromServer ? loadVoteFromWeb() : loadVoteFromFile();        
        Vote[] loadVoteFromWeb()
        {
            var client = new HttpClient();
            var response = client.GetAsync(_voteUrl, HttpCompletionOption.ResponseContentRead).Result;
            if (response.IsSuccessStatusCode)
            {
                var bytes = response.Content.ReadAsByteArrayAsync().Result;
                return JsonSerializer.Deserialize<Vote[]>(bytes);
            }
            else return new Vote[0];
        }
        Vote[] loadVoteFromFile() => JsonSerializer.Deserialize<Vote[]>(File.ReadAllText(_voteFile));
    }
}
