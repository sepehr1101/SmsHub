using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Logging.Mapping
{
    public class LogLevelMapper:Profile
    {
        public LogLevelMapper()
        {
            CreateMap< CreateLogLevelDto, Entities.LogLevel>().ReverseMap();
            CreateMap<UpdateLogLevelDto, Entities.LogLevel > ().ReverseMap();
            CreateMap<GetLogLevelDto, Entities.LogLevel > ().ReverseMap();
        }
    }
}
