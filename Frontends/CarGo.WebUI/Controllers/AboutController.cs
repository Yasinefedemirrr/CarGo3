using Microsoft.AspNetCore.Mvc;

namespace CarGo.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
