using AutoMapper;
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
        public OperationTypeDeleteHandler(
            IMapper mapper,
            IOperationTypeCommandService operationTypeCommandService,
            IOperationTypeQueryService operationTypeQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _operationTypeCommandService = operationTypeCommandService;
            _operationTypeCommandService.NotNull(nameof(operationTypeQueryService));

            _operationTypeQueryService = operationTypeQueryService;
            _operationTypeQueryService.NotNull(nameof(operationTypeQueryService));
        }
        public async Task Handle(DeleteOperationTypeDto deleteOperationTypeDto, CancellationToken cancellationToken)
        {
            var operationType = await _operationTypeQueryService.Get(deleteOperationTypeDto.Id);
            _operationTypeCommandService.Delete(operationType);
        }
    }
}
