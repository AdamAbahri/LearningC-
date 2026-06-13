using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_PROJECT.Data;
using MVC_PROJECT.Models;
using MVC_PROJECT.ViewModels.ProductsViewModels;

namespace MVC_PROJECT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            //var products = context.Products.Include(p => p.Category).AsNoTracking().ToList();// Include to load related category data (as join, fetch data from other table)
            // AsNoTracking to improve performance when we don't need to track changes to the entities (when we need to show data without modifying it)
            var productsViewModels = context.Products.Include(p => p.Category).AsNoTracking()
                .Select(p => new ProductsViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Quantity = p.Quantity,
                ImageUrl = p.ImageUrl,
                CategoryName = p.Category.Name
            }).ToList();
            return View(productsViewModels);
        }
        public IActionResult Create()
        {
            ViewBag.categories = context.Categories.AsNoTracking().ToList();
            return View();
        }
        public IActionResult Store(CreateProductsViewModel request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Quantity = request.Quantity,
                ImageUrl = request.ImageUrl,
                CategoryId = request.CategoryId
            };
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = context.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
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
            var productViewModel = new EditProductsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId
            };
            ViewBag.categories = context.Categories.ToList();
            return View(productViewModel);
        }
        public IActionResult Update(EditProductsViewModel request, int id)
        {
            var product = context.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = request.Name;
                product.Price = request.Price;
                product.Description = request.Description;
                product.Quantity = request.Quantity;
                product.ImageUrl = request.ImageUrl;
                product.CategoryId = request.CategoryId;

                context.Products.Update(product);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
