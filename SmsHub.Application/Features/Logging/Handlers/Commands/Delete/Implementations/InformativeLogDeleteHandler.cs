using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Implementations
{
    public class InformativeLogDeleteHandler : IInformativeLogDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IInformativeLogCommandService _informativeLogCommandService;
        private readonly IInformativeLogQueryService _informativeLogQueryService;
        public InformativeLogDeleteHandler(
            IMapper mapper,
            IInformativeLogCommandService informativeLogCommandService,
            IInformativeLogQueryService informativeLogQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _informativeLogCommandService = informativeLogCommandService;
            _informativeLogCommandService.NotNull(nameof(informativeLogQueryService));

            _informativeLogQueryService = informativeLogQueryService;
            _informativeLogQueryService.NotNull(nameof(informativeLogQueryService));
        }
        public async Task Handle(DeleteInformativeLogDto deleteInformativeLogDto, CancellationToken cancellationToken)
        {
            var informativeLog = await _informativeLogQueryService.Get(deleteInformativeLogDto.Id);
            _informativeLogCommandService.Delete(informativeLog);
        }
    }
}
