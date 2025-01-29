using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create
{
    public record CreateInformativeLogDto
    {
        public LogLevelEnum LogLevelId { get; }
        public string Section { get; }
        public string Description { get; }
        public Guid? UserId { get; }
        public string? UserInfo { get; }

        public CreateInformativeLogDto(LogLevelEnum logLevel, string section, string descrption, Guid? userId, string userInfo)
        {
            LogLevelId = logLevel;
            Section = section;
            Description = descrption;
            UserId = userId;
            UserInfo = userInfo;
        }
    }
}
