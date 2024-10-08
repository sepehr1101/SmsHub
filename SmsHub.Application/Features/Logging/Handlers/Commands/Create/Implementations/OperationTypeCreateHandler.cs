using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create.Implementations
{
    public class OperationTypeCreateHandler : IOperationTypeCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IOperationTypeCommandService _operationTypeCommandService;
        public OperationTypeCreateHandler(IMapper mapper, IOperationTypeCommandService operationTypeCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _operationTypeCommandService = operationTypeCommandService;
            _operationTypeCommandService.NotNull(nameof(_operationTypeCommandService));
        }

        public async Task Handle(CreateOperationTypeDto request, CancellationToken cancellationToken)
        {
            var operationType = _mapper.Map<Entities.OperationType>(request);
            await _operationTypeCommandService.Add(operationType);
        }
    }
}
