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
        public ViewResult Store(User request)
        {
            context.Users.Add(request);
            context.SaveChanges();
            return View("Create");
        }
        public string All()
        {
            return "All users";
        }
    }
}
