using Microsoft.AspNetCore.Mvc;

namespace SiteCreatorWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
