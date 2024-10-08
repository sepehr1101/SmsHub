﻿using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos;

namespace SmsHub.Application.Features.Logging.Mapping
{ 
    public class DeepLogMapper:Profile
    {
        public DeepLogMapper()
        {
            CreateMap< CreateDeepLogDto, DeepLog>().ReverseMap();
            CreateMap<UpdateDeepLogDto, DeepLog>().ReverseMap();
            CreateMap<GetDeepLogDto, DeepLog>().ReverseMap();
        }
    }
}
