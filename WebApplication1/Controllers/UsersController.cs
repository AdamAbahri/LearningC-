using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public ViewResult Index()
        {
            var users = context.Users.ToList();
            return View("Index", users);
        }
        
        public ViewResult Create()
        {
            return View("Create");
        }
        
        public IActionResult Store(User request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            context.Users.Add(request);
            context.SaveChanges();
            return Content("User created successfully");
        }
        public string All()
        {
            return "All users";
        }
    }
}
