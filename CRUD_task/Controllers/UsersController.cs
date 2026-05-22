using CRUD_task.Controllers.Data;
using CRUD_task.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_task.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var users = context.Users.ToList();
            return View("Index",users);
        }
        
        public IActionResult Create()
        {
            return View("Create");
        }

        public IActionResult Store(User request)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }       
            return View("Create", request);          
        }

        public IActionResult Details(int id)
        {
            var user = context.Users.Find(id);
            if (user == null) {
                return NotFound();
            }
            return View("Details", user);
        }

        public IActionResult Delete(int id)
        {
            var user = context.Users.Find(id);
            if (user == null) {
                return NotFound();
            }
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var user = context.Users.Find(id);
            if (user == null) {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Update(User request)
        {
            if (!ModelState.IsValid || request == null)
            {
                return View("Edit", request);                
            }       
            context.Users.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
