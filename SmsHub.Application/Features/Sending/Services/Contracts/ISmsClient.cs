using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISmsClient
    {
        Task Send(MessageBatch messageBatch, Provider provider, Domain.Features.Entities.Line line);
        Task AcountKaveTest();
        Task CancelKaveTest();
        Task CountInBoxKaveTest();
        Task DateKaveTest();
        Task LatestOutboxKaveTest();
        Task LookupKaveTest();
        Task MakettsKaveTest();
        Task ReceiveKaveTest();
        Task SelectOutboxKaveTest();
        Task SelectKaveTest();
        Task SendArrayKeveTest();
        Task SendSimpleKaveTest();
        Task StatusByMessageKaveTest();
        Task StatusKaveTest();

    }

}