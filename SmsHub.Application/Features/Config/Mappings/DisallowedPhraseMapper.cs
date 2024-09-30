using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using Entities= SmsHub.Domain.Features.Entities;
namespace SmsHub.Application.Features.Config.Mappings
{
    public class DisallowedPhraseMapper:Profile
    {
        public DisallowedPhraseMapper()
        {
            CreateMap<Entities.DisallowedPhrase, CreateDisallowedPhraseDto>().ReverseMap();
        }
    }
}
