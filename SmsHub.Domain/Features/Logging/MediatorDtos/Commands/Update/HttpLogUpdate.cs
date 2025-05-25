namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Update
{
    public record HttpLogUpdate(
        int StatusCode,
        string? ReasonPhrase,
        string? ResponseHeaders,
        string? ResponseBody,
        TimeSpan Duration
    );
}
