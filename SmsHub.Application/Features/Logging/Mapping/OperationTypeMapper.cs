using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Mapping
{
    public class OperationTypeMapper:Profile
    {
        public OperationTypeMapper()
        {
            CreateMap<Entities.OperationType, CreateOperationTypeDto>().ReverseMap();
            CreateMap<UpdateOperationTypeDto,Entities.OperationType > ().ReverseMap();
        }
    }
}
