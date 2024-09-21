using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageStateCategoryMapper:Profile
    {
        public MessageStateCategoryMapper()
        {
            CreateMap<Entities.MessageStateCategory, CreateMessageStateCategoryDto>().ReverseMap();
        }
    }
}
