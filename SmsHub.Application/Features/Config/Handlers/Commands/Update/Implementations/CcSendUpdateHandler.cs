using AutoMapper;
using FluentValidation;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class CcSendUpdateHandler : ICcSendUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly ICcSendQueryService _cSendQueryService;
        private readonly IValidator<UpdateCcSendDto> _validator;
        public CcSendUpdateHandler(
            IMapper mapper, 
            ICcSendQueryService cSendQueryService, 
            IValidator<UpdateCcSendDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _cSendQueryService = cSendQueryService;
            _cSendQueryService.NotNull(nameof(cSendQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateCcSendDto updateCcSendDto, CancellationToken cancellationToken)
        {
                   await CheckValidator(updateCcSendDto, cancellationToken);

            var ccSend = await _cSendQueryService.Get(updateCcSendDto.Id);
            _mapper.Map(updateCcSendDto, ccSend);
        }

        private async Task CheckValidator(UpdateCcSendDto updateCcSendDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateCcSendDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }
    }
}
