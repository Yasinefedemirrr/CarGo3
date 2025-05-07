
using Microsoft.AspNetCore.Mvc;

namespace CarGo.WebUI.ViewComponents.AboutViewComponents
{
    public class _BecomeADriverComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
