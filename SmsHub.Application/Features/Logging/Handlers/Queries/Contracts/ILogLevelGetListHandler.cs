﻿using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Logging.Handlers.Queries.Contracts
{
    public interface ILogLevelGetListHandler
    {
        Task<ICollection<GetLogLevelDto>> Handle();
    }
}