using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Security.Dtos.ApplicationUser;

namespace SmsHub.Api.Attributes
{
    //    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]

    public class InformativeLogFilter : ActionFilterAttribute
    {
        private IInformativeLogCreateHandler _informativeLogHandler;
        private IAppUser CurrentUser;

        private readonly LogLevelEnum _logLevelId;
        private readonly string _section;
        private readonly string _description;
        public InformativeLogFilter(LogLevelEnum logLevelId, string section, string description)
        {
            _logLevelId = logLevelId;
            _section = section;
            _description = description;

        }


        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _informativeLogHandler = context.HttpContext.RequestServices.GetRequiredService<IInformativeLogCreateHandler>();
            CurrentUser = new AppUser(context.HttpContext.User);
            CreateInformativeLogDto informativeLogDto = new
            (
                      _logLevelId,
                      _section,
                      _description,
                      CurrentUser.UserId,
                      CurrentUser.FullName
            );
            await _informativeLogHandler.Handle( informativeLogDto ,CancellationToken.None);
            await base.OnActionExecutionAsync(context, next);         
        }
    }
}
