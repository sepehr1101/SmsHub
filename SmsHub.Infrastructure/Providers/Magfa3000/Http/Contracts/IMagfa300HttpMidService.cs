using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmsHub.Domain.Providers.Magfa3000.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts
{
    public interface IMagfa300HttpMidService
    {
        Task<MagfaRequest.MidDto> Mid(MidDto midDto);
    }
}
