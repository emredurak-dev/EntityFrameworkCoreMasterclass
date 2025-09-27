using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;
using StoreFlow.Entities;
using StoreFlow.Models;

namespace StoreFlow.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreContext _context;

        public ProductController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult ProductList()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var values = _context.Categories
                .Select(x => new SelectListItem
                {
                    Value = x.CategoryId.ToString(),
                    Text = x.CategoryName

                }).ToList();
            ViewBag.categories = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var category = _context.Categories
             .Select(x => new SelectListItem
             {
                 Value = x.CategoryId.ToString(),
                 Text = x.CategoryName

             }).ToList();
            ViewBag.categories = category;

            var values = _context.Products.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult DeleteProduct(int id)
        {
            var values = _context.Products.Find(id);
            _context.Products.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult First5ProductList()
        {
            var values = _context.Products.Include(x => x.Category).Take(5).ToList();
            return View(values);
        }

        public IActionResult Last5ProductList()
        {
            var values = _context.Products.Include(y => y.Category).OrderByDescending(x => x.ProductId).Take(5).ToList();
            return View(values);
        }
        public IActionResult Skip4ProductList()
        {
            var values = _context.Products.Include(x => x.Category).Skip(4).Take(10).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProductWithAttach()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProductWithAttach(Product product)
        {
            var category = new Category { CategoryId = 2 };
            _context.Categories.Attach(category);
            var productValue = new Product
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductStock = product.ProductStock,
                Category = category
            };

            _context.Products.Add(productValue);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult ProductCount()
        {
            var value = _context.Products.LongCount();
            var lastProduct = _context.Products.OrderBy(x => x.ProductId).Last();
            ViewBag.v = value;
            ViewBag.v2 = lastProduct.ProductName;
            return View();
        }

        public IActionResult ProductListWithCategory()
        {
            var result = from c in _context.Categories
                         join p in _context.Products
                         on
                         c.CategoryId equals p.CategoryId
                         select new ProductWithCategoryViewModel
                         {
                             ProductName = p.ProductName,
                             CategoryName = c.CategoryName,
                             ProductStock = p.ProductStock
                         };
            return View(result.ToList());
        }
    }
}
