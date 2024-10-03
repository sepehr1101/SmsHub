using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Queries.Implementations
{
    public class OperationTypeGetSingleHandler: IOperationTypeGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IOperationTypeQueryService _operationTypeQueryService;
        public OperationTypeGetSingleHandler(IMapper mapper, IOperationTypeQueryService operationTypeQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _operationTypeQueryService = operationTypeQueryService;
            _operationTypeQueryService.NotNull(nameof(operationTypeQueryService));
        }
        public async Task<GetOperationTypeDto> Handle(int Id)
        {
            var operationType = await _operationTypeQueryService.Get();
            return _mapper.Map<GetOperationTypeDto>(operationType);
        }
    }
}
