using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class DisallowedPhraseMapper:Profile
    {
        public DisallowedPhraseMapper()
        {
            CreateMap<DisallowedPhrase, CreateDisallowedPhraseDto>().ReverseMap();
            CreateMap<UpdateDisallowedPhraseDto,DisallowedPhrase>().ReverseMap();
        }
    }
}
