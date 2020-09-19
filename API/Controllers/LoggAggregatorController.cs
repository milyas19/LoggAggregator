using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Create;
using Application.GetList;
using Application.GetSingleLog;
using Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggAggregatorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoggAggregatorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Return a list of logs
        /// </summary>
        /// <param name="severity"></param>
        /// <returns>List of Logs</returns>
        [HttpGet]
        public async Task<List<LogDto>> Get([FromQuery(Name ="severity")] string severity)
        {
            return await _mediator.Send(new GetListQuery(severity));
        }

        /// <summary>
        /// Return a log object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Log</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SingleLogDto>> Get(int id)
        {
            var log = await _mediator.Send(new GetLogQuery(id)); 
            return Ok(log);
        }

        /// <summary>
        /// Return a list of severity options
        /// </summary>
        /// <returns></returns>
        [HttpGet("severity")]
        public async Task<ActionResult<List<string>>> GetSeverityTypes()
        {
            var severityList = await _mediator.Send(new GetSeverityOptionsQuery());
            return Ok(severityList);
        }

        /// <summary>
        /// Create a log in database
        /// </summary>
        /// <param name="createLogDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreatedLogDto>> CreateLog([FromBody] CreateLogDto createLogDto)
        {
            var result = await _mediator.Send(new CreateLogCommand(createLogDto));
            return Ok(result);
        }
    }
}
