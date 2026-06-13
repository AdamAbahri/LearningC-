using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_PROJECT.Data;
using MVC_PROJECT.Models;

namespace MVC_PROJECT.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        
        ApplicationDbContext context = new ApplicationDbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = context.Categories.ToList(); 
            ViewBag.Products = context.Products.Include(p => p.Category).Include(p => p.Images).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
