using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Line.Mappings
{
    public class LineMapper:Profile
    {
        public LineMapper()
        {
            CreateMap< CreateLineDto, Entities.Line>().ReverseMap();
            CreateMap<UpdateLineDto, Entities.Line>().ReverseMap();
            CreateMap<GetLineDto, Entities.Line>().ReverseMap();
        }
    }
}
