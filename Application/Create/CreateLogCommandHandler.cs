using Entities;
using MediatR;
using Persistence.Data;
using Persistence.Data.DBWrapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Create
{
    public class CreateLogCommandHandler : IRequestHandler<CreateLogCommand, CreatedLogDto>
    {
        private readonly IDBWrapper<LoggAggregator> _dbWrapper;

        public CreateLogCommandHandler(IDBWrapper<LoggAggregator> dbWrapper)
        {
            _dbWrapper = dbWrapper;
        }

        public async Task<CreatedLogDto> Handle(CreateLogCommand request, CancellationToken cancellationToken)
        {
            var log = new LoggAggregator
            {
                CreatedDate = DateTime.UtcNow,
                HostName = request.Dto.HostName,
                Severity = request.Dto.Severity,
                Message = request.Dto.Message
            };
            await _dbWrapper.Add(log);

            var createdLogDto = new CreatedLogDto
            {
                Id = log.Id,
                CreatedDate = log.CreatedDate,
                HostName = log.HostName,
                Severity = log.Severity,
                Message = log.Message
            };

            return createdLogDto;
        }
    }

    public class CreateLogCommand : IRequest<CreatedLogDto>
    {
        public CreateLogDto Dto { get; set; }
        public CreateLogCommand(CreateLogDto createLogDto)
        {
            Dto = createLogDto;
        }
    }
}
