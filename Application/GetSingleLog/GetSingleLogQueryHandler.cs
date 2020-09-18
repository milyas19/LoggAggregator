using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
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
        private readonly LoggAggregatorContext _loggContext;
        private readonly IMapper _mapper;

        public GetSingleLogQueryHandler(LoggAggregatorContext loggContext, IMapper mapper)
        {
            _loggContext = loggContext;
            _mapper = mapper;
        }

        public async Task<SingleLogDto> Handle(GetLogQuery request, CancellationToken cancellationToken)
        {
            var log = await _loggContext.LoggAggregators.FirstOrDefaultAsync(l => l.Id == request.Id);
            return _mapper.Map<SingleLogDto>(log);
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
