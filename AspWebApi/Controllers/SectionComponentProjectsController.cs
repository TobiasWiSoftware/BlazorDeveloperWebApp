using Microsoft.AspNetCore.Mvc;

namespace ASPWebAPI.Controllers
{
    public class SectionComponentProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
