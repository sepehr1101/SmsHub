using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Implementations
{
    public class InformativeLogUpdateHandler : IInformativeLogUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IInformativeLogQueryService _informativeLogQueryService;
        private readonly IValidator<UpdateInformativeLogDto> _validator;
        public InformativeLogUpdateHandler(
            IMapper mapper,
            IInformativeLogQueryService informativeLogQueryService, 
            IValidator<UpdateInformativeLogDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _informativeLogQueryService = informativeLogQueryService;
            _informativeLogQueryService.NotNull(nameof(informativeLogQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateInformativeLogDto updateInformativeLogDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateInformativeLogDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var informativeLog = await _informativeLogQueryService.Get(updateInformativeLogDto.Id);
            _mapper.Map(updateInformativeLogDto, informativeLog);
        }
    }
}
