using Microsoft.AspNetCore.Mvc;

namespace CarGo.WebUI.ViewComponents.CarDetailViewComponents
{
     public class _CarDetailTabPaneComponentPartial : ViewComponent
     {
         public IViewComponentResult Invoke()
         {
             return View();
         }
     }
}
