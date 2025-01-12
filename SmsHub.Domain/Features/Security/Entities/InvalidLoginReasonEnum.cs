namespace SmsHub.Domain.Features.Security.Entities
{
    public enum InvalidLoginReasonEnum:short
    {
        InvalidUserName=1,
        InvalidPasswor=2,
        InvalidTwoStepVerification=3,
        ExpireTwoStepVerification=4,
        TryingAfterLock=5,
        TryingByDisableUser=6,
    }
}
