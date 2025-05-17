using Microsoft.AspNetCore.Mvc;

namespace CarGo.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View();  
        }
    }
}
