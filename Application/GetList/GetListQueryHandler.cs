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
    public class GetListQueryHandler : IRequestHandler<GetListQuery, List<LogDto>>
    {
        private readonly IDBWrapper<LoggAggregator> _dbWrapper;
        private readonly IMapper _mapper;

        public GetListQueryHandler(IDBWrapper<LoggAggregator> dbWrapper, IMapper mapper)
        {
            _dbWrapper = dbWrapper;
            _mapper = mapper;
        }

        public async Task<List<LogDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            //Can also use Take() or Skip() for pagination
            var logEntityList = await _dbWrapper.GetList();
            if (!string.IsNullOrEmpty(request.Severity))
            {
                logEntityList = logEntityList.Where(s => s.Severity.ToLower() == request.Severity).ToList();
            }
            return _mapper.Map<List<LogDto>>(logEntityList);
        }
    }

    public class GetListQuery : IRequest<List<LogDto>>
    {
        public string Severity { get; set; }
        public GetListQuery(string? severity)
        {
            Severity = severity;
        }
    }
}
