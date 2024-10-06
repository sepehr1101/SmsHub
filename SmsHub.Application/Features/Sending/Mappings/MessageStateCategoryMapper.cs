using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageStateCategoryMapper:Profile
    {
        public MessageStateCategoryMapper()
        {
            CreateMap<CreateMessageStateCategoryDto, MessageStateCategory>().ReverseMap();
            CreateMap<UpdateMessageStateCategoryDto, MessageStateCategory > ().ReverseMap();
            CreateMap<GetMessageStateCategoryDto, MessageStateCategory > ().ReverseMap();
        }
    }
}
