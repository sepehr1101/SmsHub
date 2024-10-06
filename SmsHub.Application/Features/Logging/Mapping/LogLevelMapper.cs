using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Update;

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
