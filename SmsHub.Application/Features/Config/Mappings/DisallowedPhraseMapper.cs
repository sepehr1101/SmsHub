using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class DisallowedPhraseMapper:Profile
    {
        public DisallowedPhraseMapper()
        {
            CreateMap< CreateDisallowedPhraseDto, DisallowedPhrase>().ReverseMap();
            CreateMap<UpdateDisallowedPhraseDto,DisallowedPhrase>().ReverseMap();
            CreateMap<GetDisallowedPhraseDto,DisallowedPhrase>().ReverseMap();
        }
    }
}
