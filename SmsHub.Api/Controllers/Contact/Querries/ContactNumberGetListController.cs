using Microsoft.AspNetCore.Mvc;

namespace SmsHub.Api.Controllers.Contact.Querries
{
    public class ContactNumberGetListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
