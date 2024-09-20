using AutoMapper;
using MediatR;
using SmsHub.Common;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create
{
    public class CreateOperationTypeCommandHandler : IRequestHandler<CreateOperationTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly IOperationTypeCommandService _operationTypeCommandService;
        public CreateOperationTypeCommandHandler(IMapper mapper, IOperationTypeCommandService operationTypeCommandService)
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
