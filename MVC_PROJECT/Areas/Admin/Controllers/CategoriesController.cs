using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_PROJECT.Data;
using MVC_PROJECT.Models;
using MVC_PROJECT.ViewModels.CategoriesViewModels;

namespace MVC_PROJECT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var categoriesViewModel = context.Categories.AsNoTracking()
                .Select(c => new CategoriesViewModel {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return View(categoriesViewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Store(CreateCategoriesViewModel request)
        {
            var category = new Category
            {
                Name = request.Name
            };
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var category = context.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            var categoryViewModel = new EditCategoriesViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
            return View(categoryViewModel);
        }
        public IActionResult Update(EditCategoriesViewModel request,int id)
        {
            var category = context.Categories.Find(id);
            if (category != null)
            {
                category.Name = request.Name;
                context.Categories.Update(category);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}