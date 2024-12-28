using AutoMapper;
using FluentValidation;
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
            var validationResult = await _validator.ValidateAsync(updateCcSendDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var ccSend = await _cSendQueryService.Get(updateCcSendDto.Id);
            _mapper.Map(updateCcSendDto, ccSend);
        }
    }
}
