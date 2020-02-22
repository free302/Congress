using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrBAE.Congress.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private static readonly (int, decimal rate, decimal seat)[] _sample = new[]
        {
            (0, 0m,20),
            (1, 40.40m,116m), (2, 32.10m,91m), (3, 4.10m,7m),(4, 3.80m,8m),(5, 4.40m,2m),
            (6, 1.70m,2m), (7, 1.10m,3m), (8, 1.0m,1m), (9, 1.5m,3m),
            (int.MaxValue, 9.9m,0)
        };

        private readonly ILogger<VoteController> _logger;
        public VoteController(ILogger<VoteController> logger) => _logger = logger;

        // GET: api/Vote
        [HttpGet]
        public IEnumerable<Vote> Get()
        {
            var list = new Vote[_sample.Length];
            for (int i = 0; i < _sample.Length - 1; i++) list[i] = new Vote(i, _sample[i].rate, _sample[i].seat);
            list[^1] = new Vote(int.MaxValue, _sample[^1].rate, _sample[^1].seat);
            return list;
        }

        // GET: api/Vote/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vote
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Vote/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
