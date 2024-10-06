using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Update;

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
