using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public record CreateConsumerSafeIpDto:IRequest
    {
        //todo : everyone null?
        public int ConsumerId { get; set; }
        public string FromIp { get; set; } = null!;//todo : is it null?
        public string ToIp { get; set; } = null!;// todo: is it null?
        public bool IsV6 { get; set; }
    }
}
