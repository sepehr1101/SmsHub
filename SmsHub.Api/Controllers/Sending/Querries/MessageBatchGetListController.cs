using Microsoft.AspNetCore.Mvc;

namespace SmsHub.Api.Controllers.Sending.Querries
{
    public class MessageBatchGetListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
