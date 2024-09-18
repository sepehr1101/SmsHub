using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public record CreateConsumerLineDto:IRequest
    {
        //todo : everyone null?
        public int ConsumerId { get; set; }
        public int LineId { get; set; }
    }
}
