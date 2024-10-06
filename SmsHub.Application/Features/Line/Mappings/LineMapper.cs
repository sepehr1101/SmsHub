using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Line.Mappings
{
    public class LineMapper:Profile
    {
        public LineMapper()
        {
            CreateMap<Entities.Line, CreateLineDto>().ReverseMap();
            CreateMap<UpdateLineDto, Entities.Line>().ReverseMap();
        }
    }
}
