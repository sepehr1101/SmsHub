using Microsoft.AspNetCore.Mvc;

namespace SmsHub.Api.Controllers.Sending.Querries
{
    public class MessageStateGetListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
