namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface ICheckRoleByCollectionIdHandler
    {
        Task<int> Handle(ICollection<int> roleIds);
    }
}
