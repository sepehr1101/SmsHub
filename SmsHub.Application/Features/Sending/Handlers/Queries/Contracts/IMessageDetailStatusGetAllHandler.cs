﻿using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Contracts
{
    public interface IMessageDetailStatusGetAllHandler
    {
        Task<ICollection<GetMessageDetailStatusDto>> Handle();
    }
}
