namespace SmsHub.Domain.Features.Security.Entities
{
    public enum LogoutReasonEnum : short
    {
        ByUser=1,
        ByAdmin=2,
        ChangePasswordByUser=3,
        EditByAdmin=4,
        ExpireToken=5,
        ChangeIpInSession=6,
        ChangeWebClientSpecification=7,
        LoginAtSameTime=8,
    }
}
