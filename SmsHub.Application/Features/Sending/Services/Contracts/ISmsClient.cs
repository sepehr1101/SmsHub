using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISmsClient
    {
        Task Send(MessageBatch messageBatch, Provider provider, Domain.Features.Entities.Line line);
        Task SendKaveTest();
    }
}