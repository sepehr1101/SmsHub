using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Template.Mappings
{
    public class TemplateMapping:Profile
    {
        public TemplateMapping()
        {
            CreateMap<Entities.Template, CreateTemplateDto>().ReverseMap();
            CreateMap<UpdateTemplateDto, Entities.Template > ().ReverseMap();
        }
    }
}
