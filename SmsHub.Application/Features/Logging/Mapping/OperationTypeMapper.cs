using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Logging.Mapping
{
    public class OperationTypeMapper:Profile
    {
        public OperationTypeMapper()
        {
            CreateMap< CreateOperationTypeDto, Entities.OperationType>().ReverseMap();
            CreateMap<UpdateOperationTypeDto,Entities.OperationType > ().ReverseMap();
            CreateMap<GetOperationTypeDto,Entities.OperationType > ().ReverseMap();
        }
    }
}
