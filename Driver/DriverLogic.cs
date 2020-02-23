using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DrBAE.Congress.Common;

namespace DrBAE.Congress.Driver
{
    public class DriverLogic : IDriver
    {
        public Party[] GetPartyData(bool fromServer) => fromServer ? loadPartyFromWeb() : loadPartyFromFile();
        Party[] loadPartyFromFile()
        {
            const string voteFile = "PartyData.json";
            return JsonSerializer.Deserialize<Party[]>(File.ReadAllText(voteFile));
        }
        Party[] loadPartyFromWeb()
        {
            const string voteUrl = "https://localhost:44318/party";
            var client = new HttpClient();
            var response = client.GetAsync(voteUrl, HttpCompletionOption.ResponseContentRead).Result;
            if (response.IsSuccessStatusCode)
            {
                var bytes = response.Content.ReadAsByteArrayAsync().Result;
                return JsonSerializer.Deserialize<Party[]>(bytes);
            }
            else return new Party[0];
        }

        public Vote[] GetVoteData(bool fromServer) => fromServer ? loadVoteFromWeb() : loadVoteFromFile();        
        Vote[] loadVoteFromWeb()
        {
            const string voteUrl = "https://localhost:44318/vote";
            var client = new HttpClient();
            var response = client.GetAsync(voteUrl, HttpCompletionOption.ResponseContentRead).Result;
            if (response.IsSuccessStatusCode)
            {
                var bytes = response.Content.ReadAsByteArrayAsync().Result;
                return JsonSerializer.Deserialize<Vote[]>(bytes);
            }
            else return new Vote[0];
        }
        Vote[] loadVoteFromFile()
        {
            const string voteFile = "VoteData.json";
            return JsonSerializer.Deserialize<Vote[]>(File.ReadAllText(voteFile));
        }        
    }
}
