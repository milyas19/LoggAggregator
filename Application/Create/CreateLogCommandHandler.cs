using Entities;
using MediatR;
using Persistence.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Create
{
    public class CreateLogCommandHandler : IRequestHandler<CreateLogCommand, CreatedLogDto>
    {
        private readonly LoggAggregatorContext _loggContext;

        public CreateLogCommandHandler(LoggAggregatorContext loggContext)
        {
            _loggContext = loggContext;
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
            _loggContext.LoggAggregators.Add(log);
            await _loggContext.SaveChangesAsync();

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
