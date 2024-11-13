using Microsoft.AspNetCore.Mvc;

namespace SmsHub.Api.Controllers.Logging.Querries
{
    public class LogLevelGetListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
