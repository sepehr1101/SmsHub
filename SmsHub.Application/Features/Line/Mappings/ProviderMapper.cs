using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Line.Mappings
{
    public class ProviderMapper:Profile
    {
        public ProviderMapper()
        {
            CreateMap< CreateProviderDto, Provider>().ReverseMap();
            CreateMap<UpdateProviderDto,Provider>().ReverseMap();
            CreateMap<GetProviderDto,Provider>().ReverseMap();
        }
    }
}
