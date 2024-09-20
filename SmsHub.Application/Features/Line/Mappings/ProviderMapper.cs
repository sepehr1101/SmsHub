using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Line.Mappings
{
    public class ProviderMapper:Profile
    {
        public ProviderMapper()
        {
            CreateMap<Entities.Provider, CreateProviderDto>().ReverseMap();
        }
    }
}
