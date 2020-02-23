using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using DrBAE.Congress.Common;
using System.Net.Http;

namespace DrBAE.Congress.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly ILogger<PartyController> _logger;
        public PartyController(ILogger<PartyController> logger) => _logger = logger;

        // GET: api/Vote
        [HttpGet]
        public IActionResult Get()
        {
            var list = DataLoader.LoadParty();
            var bytes = JsonSerializer.SerializeToUtf8Bytes(list);
            return new FileContentResult(bytes, "application/octet-stream");
        }

        // GET: api/Vote/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var list = DataLoader.LoadParty();
            return JsonSerializer.Serialize(list, new JsonSerializerOptions() { WriteIndented = true });
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
