using Microsoft.AspNetCore.Mvc;

namespace MVC_PROJECT.Areas.Admin.Controllers
{
    [Area("Admin")] 
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
