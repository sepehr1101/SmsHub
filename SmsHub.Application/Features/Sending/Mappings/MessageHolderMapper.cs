﻿using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageHolderMapper:Profile
    {
        public MessageHolderMapper()
        {
            CreateMap< CreateMessagesHolderDto, MessagesHolder>().ReverseMap();
            CreateMap<UpdateMessageHolderDto, MessagesHolder > ().ReverseMap();
            CreateMap<GetMessageHolderDto, MessagesHolder > ().ReverseMap();
        }
    }
}
