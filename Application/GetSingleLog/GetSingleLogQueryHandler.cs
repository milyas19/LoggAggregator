using AutoMapper;
using Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Data.DBWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.GetSingleLog
{
    public class GetSingleLogQueryHandler : IRequestHandler<GetLogQuery, SingleLogDto>
    {
        private readonly IDBWrapper<LoggAggregator> _dbWrapper;

        public GetSingleLogQueryHandler(IDBWrapper<LoggAggregator> dbWrapper)
        {
            _dbWrapper = dbWrapper;
        }

        public async Task<SingleLogDto> Handle(GetLogQuery request, CancellationToken cancellationToken)
        {
            var log = await _dbWrapper.GetSingle(request.Id);

            var logDto = new SingleLogDto
            {
                Id = log.Id,
                CreatedDate = log.CreatedDate,
                HostName = log.HostName,
                Severity = log.Severity,
                Message = log.Message
            };
            
            return logDto;
        }
    }

    public class GetLogQuery : IRequest<SingleLogDto>
    {
        public int Id { get; }
        public GetLogQuery(int id)
        {
            Id = id;
        }

    }
}
