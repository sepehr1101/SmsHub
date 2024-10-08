﻿using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Implementations
{
    public class OperationTypeUpdateHandler: IOperationTypeUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IOperationTypeQueryService _operationTypeQueryService;
        public OperationTypeUpdateHandler(IMapper mapper, IOperationTypeQueryService operationTypeQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _operationTypeQueryService = operationTypeQueryService;
            _operationTypeQueryService.NotNull(nameof(operationTypeQueryService));
        }
        public async Task Handle(UpdateOperationTypeDto updateOperationTypeDto, CancellationToken cancellationToken)
        {
            var operationType = await _operationTypeQueryService.Get(updateOperationTypeDto.Id);
            _mapper.Map(updateOperationTypeDto, operationType);
        }
    }
}
