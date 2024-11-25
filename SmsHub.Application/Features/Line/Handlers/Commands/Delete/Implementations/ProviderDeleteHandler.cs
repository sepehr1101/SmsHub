using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Delete.Implementations
{
    public class ProviderDeleteHandler : IProviderDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IProviderCommandService _providerCommandService;
        private readonly IProviderQueryService _providerQueryService;
        private readonly IValidator<DeleteProviderDto> _validator;
        public ProviderDeleteHandler(
            IMapper mapper,
            IProviderCommandService providerCommandService,
            IProviderQueryService providerQueryService,
            IValidator<DeleteProviderDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull();

            _providerCommandService = providerCommandService;
            _providerCommandService.NotNull(nameof(providerCommandService));

            _providerQueryService = providerQueryService;
            _providerQueryService.NotNull(nameof(providerQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteProviderDto deleteProviderDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteProviderDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var provider = await _providerQueryService.Get(deleteProviderDto.Id);
            _providerCommandService.Delete(provider);
        }
    }
}
