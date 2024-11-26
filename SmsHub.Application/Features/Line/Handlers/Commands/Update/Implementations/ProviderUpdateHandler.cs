using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Delete.Implementations
{
    public class ProviderUpdateHandler : IProviderUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IProviderQueryService _providerQueryService;
        private readonly IValidator<UpdateProviderDto> _validator;
        public ProviderUpdateHandler(
            IMapper mapper,
            IProviderQueryService providerQueryService,
            IValidator<UpdateProviderDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _providerQueryService = providerQueryService;
            _providerQueryService.NotNull(nameof(providerQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateProviderDto updateProviderDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateProviderDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var provider = await _providerQueryService.Get(updateProviderDto.Id);
            _mapper.Map(updateProviderDto, provider);
        }
    }
}
