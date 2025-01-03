﻿using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using FluentValidation;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Create.Implementations
{
    public class ProviderCreateHandler : IProviderCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IProviderCommandService _providerCommandService;
        private readonly IValidator<CreateProviderDto> _validator;
        public ProviderCreateHandler(
            IMapper mapper,
            IProviderCommandService providerCommandService, 
            IValidator<CreateProviderDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _providerCommandService = providerCommandService;
            _providerCommandService.NotNull(nameof(_providerCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateProviderDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var provider = _mapper.Map<Entities.Provider>(request);
            await _providerCommandService.Add(provider);
        }
    }
}
