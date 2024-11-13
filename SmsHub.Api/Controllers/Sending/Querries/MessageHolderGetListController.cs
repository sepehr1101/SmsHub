using Microsoft.AspNetCore.Mvc;

namespace SmsHub.Api.Controllers.Sending.Querries
{
    public class MessageHolderGetListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
