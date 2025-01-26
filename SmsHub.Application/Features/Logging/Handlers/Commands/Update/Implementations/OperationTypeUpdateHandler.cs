using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Implementations
{
    public class OperationTypeUpdateHandler : IOperationTypeUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IOperationTypeQueryService _operationTypeQueryService;
        private readonly IValidator<UpdateOperationTypeDto> _validator;
        public OperationTypeUpdateHandler(
            IMapper mapper, 
            IOperationTypeQueryService operationTypeQueryService, 
            IValidator<UpdateOperationTypeDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _operationTypeQueryService = operationTypeQueryService;
            _operationTypeQueryService.NotNull(nameof(operationTypeQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateOperationTypeDto updateOperationTypeDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateOperationTypeDto, cancellationToken);

            var operationType = await _operationTypeQueryService.Get(updateOperationTypeDto.Id);
            _mapper.Map(updateOperationTypeDto, operationType);
        }
        private async Task CheckValidator(UpdateOperationTypeDto updateOperationTypeDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateOperationTypeDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }

    }
}
