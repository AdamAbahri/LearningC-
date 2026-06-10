using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_PROJECT.Data;
using MVC_PROJECT.Models;

namespace MVC_PROJECT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            ViewBag.categories = context.Categories.ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.categories = context.Categories.ToList();
            return View();
        }
        public IActionResult Store(Product request)
        {
            context.Products.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            ViewBag.categories = context.Categories.ToList();
            return View(product);
        }
        public IActionResult Update(Product request, int id)
        {
            request.Id = id;

            context.Products.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
