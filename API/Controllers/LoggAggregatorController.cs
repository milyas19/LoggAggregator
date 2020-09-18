using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggAggregatorController : ControllerBase
    {
        private readonly LoggAggregatorContext _loggAggregatorContext;
        public LoggAggregatorController(LoggAggregatorContext loggAggregatorContext)
        {
            _loggAggregatorContext = loggAggregatorContext;
        }

        // GET: api/<LoggAggregatorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoggAggregatorController>/5
        [HttpGet("{id}")]
        public ActionResult<LoggAggregator> Get(int id)
        {
            var log = _loggAggregatorContext.LoggAggregators.Where(x => x.Id == id);
            return Ok(log);
        }

        // POST api/<LoggAggregatorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
