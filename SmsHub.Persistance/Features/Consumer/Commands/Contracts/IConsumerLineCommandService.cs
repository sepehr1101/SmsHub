using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Persistence.Features.Consumer.Commands.Contracts
{
    public interface IConsumerLineCommandService
    {
        Task Add(Domain.Features.Entities.ConsumerLine consumerLine);
        Task Add(ICollection<Domain.Features.Entities.ConsumerLine> consumerLines);
    }
}
