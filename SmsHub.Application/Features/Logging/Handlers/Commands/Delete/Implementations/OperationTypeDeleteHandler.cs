using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Implementations
{
    public class OperationTypeDeleteHandler : IOperationTypeDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IOperationTypeCommandService _operationTypeCommandService;
        private readonly IOperationTypeQueryService _operationTypeQueryService;
        private readonly IValidator<DeleteOperationTypeDto> _validator;
        public OperationTypeDeleteHandler(
            IMapper mapper,
            IOperationTypeCommandService operationTypeCommandService,
            IOperationTypeQueryService operationTypeQueryService,
            IValidator<DeleteOperationTypeDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _operationTypeCommandService = operationTypeCommandService;
            _operationTypeCommandService.NotNull(nameof(operationTypeQueryService));

            _operationTypeQueryService = operationTypeQueryService;
            _operationTypeQueryService.NotNull(nameof(operationTypeQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteOperationTypeDto deleteOperationTypeDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteOperationTypeDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var operationType = await _operationTypeQueryService.Get(deleteOperationTypeDto.Id);
            _operationTypeCommandService.Delete(operationType);
        }
    }
}
