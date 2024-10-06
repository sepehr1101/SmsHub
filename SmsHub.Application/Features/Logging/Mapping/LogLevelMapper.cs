using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Logging.Mapping
{
    public class LogLevelMapper:Profile
    {
        public LogLevelMapper()
        {
            CreateMap<Entities.LogLevel, CreateLogLevelDto>().ReverseMap();
            CreateMap<UpdateLogLevelDto, Entities.LogLevel > ().ReverseMap();
        }
    }
}
