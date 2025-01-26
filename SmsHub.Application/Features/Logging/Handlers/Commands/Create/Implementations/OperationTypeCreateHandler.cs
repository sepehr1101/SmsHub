using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using FluentValidation;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create.Implementations
{
    public class OperationTypeCreateHandler : IOperationTypeCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IOperationTypeCommandService _operationTypeCommandService;
        private readonly IValidator<CreateOperationTypeDto> _validator;
        public OperationTypeCreateHandler(
            IMapper mapper,
            IOperationTypeCommandService operationTypeCommandService,
            IValidator<CreateOperationTypeDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _operationTypeCommandService = operationTypeCommandService;
            _operationTypeCommandService.NotNull(nameof(_operationTypeCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateOperationTypeDto createOperationTypeDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createOperationTypeDto, cancellationToken);

            var operationType = _mapper.Map<Entities.OperationType>(createOperationTypeDto);
            await _operationTypeCommandService.Add(operationType);
        }
        private async Task CheckValidator(CreateOperationTypeDto createOperationTypeDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createOperationTypeDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }

    }
}
