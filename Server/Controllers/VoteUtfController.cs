using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using DrBAE.Congress.Common;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace DrBAE.Congress.Server.Controllers
{
    [Route("[controller]")]
    public class VoteUtfController : ControllerBase
    {
        private static readonly (int, decimal rate, decimal seat)[] _sample = new[]
        {
            (0, 0m,20),
            (1, 40.40m,116m), (2, 32.10m,91m), (3, 4.10m,7m),(4, 3.80m,8m),(5, 4.40m,2m),
            (6, 1.70m,2m), (7, 1.10m,3m), (8, 1.0m,1m), (9, 1.5m,3m),
            (int.MaxValue, 9.9m,0)
        };

        private readonly ILogger<VoteUtfController> _logger;
        public VoteUtfController(ILogger<VoteUtfController> logger) => _logger = logger;

        // GET: api/Vote
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = new Vote[_sample.Length];
            for (int i = 0; i < _sample.Length - 1; i++) list[i] = new Vote(i, _sample[i].rate, _sample[i].seat);
            list[^1] = new Vote(int.MaxValue, _sample[^1].rate, _sample[^1].seat);

            var opt = new JsonSerializerOptions() { WriteIndented = true };

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(list));
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;

            //return JsonSerializer.Serialize(list, opt);
            //return JsonSerializer.SerializeToUtf8Bytes(list);
        }

    }
}