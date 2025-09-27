using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;

namespace StoreFlow.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreContext _context;

        public CategoryController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.CategoryStatus = false;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            var values = _context.Categories.Find(id);
            _context.Categories.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var values = _context.Categories.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult ReverseCategory()
        {
            var categoryValue = _context.Categories.First();
            ViewBag.v = categoryValue.CategoryName;

            var categoryValue2 = _context.Categories.SingleOrDefault(x => x.CategoryName == "Computer & Accessories");
            ViewBag.v2 = categoryValue2.CategoryStatus + " - " + categoryValue2.CategoryId.ToString() + " - " + categoryValue2.CategoryName;

            var values = _context.Categories.OrderBy(x => x.CategoryId).ToList();
            values.Reverse();
            return View(values);
        }
    }
}
