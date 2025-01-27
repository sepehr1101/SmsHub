using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using FluentValidation;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class CcSendCreateHandler : ICcSendCreateHandler
    {
        private readonly ICcSendCommandService _ccSendCommandService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCcSendDto> _validator;
        public CcSendCreateHandler(
            ICcSendCommandService ccSendCommandService, 
            IMapper mapper, 
            IValidator<CreateCcSendDto> validator)
        {
            _ccSendCommandService = ccSendCommandService;
            _ccSendCommandService.NotNull(nameof(_ccSendCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }
        public async Task Handle(CreateCcSendDto createCcSendDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createCcSendDto, cancellationToken);

            var ccSend = _mapper.Map<Entities.CcSend>(createCcSendDto);
            await _ccSendCommandService.Add(ccSend);
        }

        private async Task CheckValidator(CreateCcSendDto createCcSendDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createCcSendDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }
    }
}
