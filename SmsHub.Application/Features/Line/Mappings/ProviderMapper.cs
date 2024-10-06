using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Line.Mappings
{
    public class ProviderMapper:Profile
    {
        public ProviderMapper()
        {
            CreateMap<Provider, CreateProviderDto>().ReverseMap();
            CreateMap<UpdateProviderDto,Provider>().ReverseMap();
        }
    }
}
