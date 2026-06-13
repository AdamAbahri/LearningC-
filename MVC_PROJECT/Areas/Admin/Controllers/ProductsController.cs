using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_PROJECT.Data;
using MVC_PROJECT.Models;
using MVC_PROJECT.ViewModels.ProductsViewModels;
using MVC_PROJECT.ViewModels.ImageViewModels; 

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
            var productsViewModels = context.Products.Include(p => p.Category).Include(p => p.Images).AsNoTracking()
               .Select(p => new ProductsViewModel
               {
                   Id = p.Id,
                   Name = p.Name,
                   Price = p.Price,
                   Description = p.Description,
                   Quantity = p.Quantity,
                   CategoryName = p.Category.Name,

                   Images = p.Images
                .Select(i => i.ImageUrl)
                .ToList()
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
                CategoryId = request.CategoryId
            };
            context.Products.Add(product);
            context.SaveChanges();

            if (request.Images != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                foreach (var image in request.Images)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                    string path = Path.Combine(uploadsFolder, fileName);

                    using var stream = new FileStream(path, FileMode.Create);
                    image.CopyTo(stream);

                    context.ProductImages.Add(new ProductImage
                    {
                        ProductId = product.Id,
                        ImageUrl = "/uploads/" + fileName
                    });
                }

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = context.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == id);
            if (product != null)
            {

                foreach (var image in product.Images)
                {
                    var filePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot" + image.ImageUrl.Replace("/", Path.DirectorySeparatorChar.ToString()));

                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);
                }

                context.Products.Remove(product);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var product = context.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == id);

            if (product == null) return NotFound();

            var productViewModel = new EditProductsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                ExistingImages = product.Images.Select(i => new ImagesViewModel // ← هنا التعديل
                {
                    Id = i.Id,
                    Url = i.ImageUrl
                }).ToList()
            };

            ViewBag.categories = context.Categories.ToList();
            return View(productViewModel);
        }
        public IActionResult Update(EditProductsViewModel request)
        {
            var product = context.Products
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == request.Id);

            if (product == null) return NotFound();

            product.Name = request.Name;
            product.Price = request.Price;
            product.Description = request.Description;
            product.Quantity = request.Quantity;
            product.CategoryId = request.CategoryId;

            if (request.Images != null && request.Images.Count > 0)
            {
                // ← Fix 1: Create the folder if it doesn't exist
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                // ← Fix 2: foreach to handle multiple images
                foreach (var image in request.Images)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                    string path = Path.Combine(uploadsFolder, fileName);

                    using var stream = new FileStream(path, FileMode.Create);
                    image.CopyTo(stream);

                    context.ProductImages.Add(new ProductImage
                    {
                        ProductId = product.Id,
                        ImageUrl = "/uploads/" + fileName
                    });
                }
            }

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteImage(int id)
        {
            var image = context.ProductImages.Find(id);
            if (image == null) return NotFound();

            int productId = image.ProductId;

            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot" + image.ImageUrl.Replace("/", Path.DirectorySeparatorChar.ToString()));

            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);

            context.ProductImages.Remove(image);
            context.SaveChanges();

            return RedirectToAction("Edit", new { id = productId });
        }

    }
}
