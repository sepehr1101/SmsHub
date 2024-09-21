using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Template.Mappings
{
    public class TemplateCategoryMapping:Profile
    {
        public TemplateCategoryMapping()
        {
            CreateMap<Entities.TemplateCategory, CreateTemplateCategoryDto>().ReverseMap();
        }
    }
}
