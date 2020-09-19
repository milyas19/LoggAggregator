using AutoMapper;
using Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Data.DBWrapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.GetList
{
    public class GetSeverityOptionsHandler : IRequestHandler<GetSeverityOptionsQuery, List<string>>
    {
        private readonly IDBWrapper<LoggAggregator> _dbWrapper;

        public GetSeverityOptionsHandler(IDBWrapper<LoggAggregator> dbWrapper)
        {
            _dbWrapper = dbWrapper;
        }

        public async Task<List<string>> Handle(GetSeverityOptionsQuery request, CancellationToken cancellationToken)
        {
            var logEntityList = await _dbWrapper.GetList();
           return  logEntityList.Select(x => x.Severity).Distinct().ToList();
        }
    }

    public class GetSeverityOptionsQuery : IRequest<List<string>>
    {
      
    }
}
