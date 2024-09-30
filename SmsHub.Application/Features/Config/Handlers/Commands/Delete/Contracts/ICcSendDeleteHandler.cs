using SmsHub.Domain.Features.Line.MediatorDtos.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts
{
    public interface ICcSendDeleteHandler
    {
        Task Handle(DeleteCcSendtDto deleteProviderDto, CancellationToken cancellationToken);

    }
}
