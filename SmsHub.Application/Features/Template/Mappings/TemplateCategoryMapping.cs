using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Template.Mappings
{
    public class TemplateCategoryMapping:Profile
    {
        public TemplateCategoryMapping()
        {
            CreateMap<CreateTemplateCategoryDto, TemplateCategory>().ReverseMap();
            CreateMap<UpdateTemplateCategoryDto,TemplateCategory > ().ReverseMap();
            CreateMap<GetTemplateCategoryDto,TemplateCategory > ().ReverseMap();
        }
    }
}
