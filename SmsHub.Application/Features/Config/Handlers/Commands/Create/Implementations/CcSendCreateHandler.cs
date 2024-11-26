using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using MediatR;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using FluentValidation;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class CcSendCreateHandler : ICcSendCreateHandler
    {
        private readonly ICcSendCommandService _ccSendCommandService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCcSendDto> _validator;
        public CcSendCreateHandler(ICcSendCommandService ccSendCommandService, IMapper mapper, IValidator<CreateCcSendDto> validator)
        {
            _ccSendCommandService = ccSendCommandService;
            _ccSendCommandService.NotNull(nameof(_ccSendCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }
        public async Task Handle(CreateCcSendDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var ccSend = _mapper.Map<Entities.CcSend>(request);
            await _ccSendCommandService.Add(ccSend);
        }
    }
}
