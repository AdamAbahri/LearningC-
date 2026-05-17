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
            if (request == null || !ModelState.IsValid) // is valid refers to the validation attributes in the User model
            {
                return View("Create",request);
            }
            context.Users.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id) {
            var user = context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("Details", user);
        }

        public IActionResult Delete(int id) {
            var user = context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) {
            var user = context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("Edit", user);
        }
        public IActionResult Update(User request)
        {
            if (request == null || !ModelState.IsValid) // is valid refers to the validation attributes in the User model
            {
                return RedirectToAction("Index");
            }
            context.Users.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public string All()
        {
            return "All users";
        }
    }
}
