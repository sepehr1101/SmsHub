using AutoMapper;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Template.Mappings
{
    public class TemplateCategoryMapping:Profile
    {
        public TemplateCategoryMapping()
        {
            CreateMap<TemplateCategory, CreateTemplateCategoryDto>().ReverseMap();
            CreateMap<UpdateTemplateCategoryDto,TemplateCategory > ().ReverseMap();
        }
    }
}
