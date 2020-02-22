using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
//using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DrBAE.Congress.Common;

namespace DrBAE.Congress.Driver
{
    public class DriverLogic : IDriver
    {
        public Vote[] GetVoteData()
        {
            return loadFromWeb();
        }

        Vote[] loadFromWeb()
        {
            const string voteUrl = "https://localhost:44318/voteutf";
            var client = new HttpClient();
            var response = client.GetAsync(voteUrl).Result;
            if (response.IsSuccessStatusCode)
                return JsonSerializer.Deserialize<Vote[]>(response.Content.ReadAsByteArrayAsync().Result);
            else return new Vote[0];
        }

        Vote[] loadFromFile()
        {
            const string voteFile = "SampleVoteData.json";
            return JsonSerializer.Deserialize<Vote[]>(File.ReadAllText(voteFile));
        }

    }
}
