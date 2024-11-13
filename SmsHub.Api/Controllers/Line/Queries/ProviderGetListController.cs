using Microsoft.AspNetCore.Mvc;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Line.Queries
{
    [Route(nameof(Provider))]
    [ApiController]
    public class ProviderGetListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
