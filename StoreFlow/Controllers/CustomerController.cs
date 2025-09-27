using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;
using StoreFlow.Models;

namespace StoreFlow.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreContext _context;

        public CustomerController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult CustomerListOrderByCustomerName()
        {
            var values = _context.Customers.OrderBy(x => x.CustomerName + x.CustomerSurname).ToList();
            return View(values);
        }

        public IActionResult CustomerListOrderByDescBalance()
        {
            var values = _context.Customers.OrderByDescending(x => x.CustomerBalance).ToList();
            return View(values);
        }

        public IActionResult CustomerGetByCity(string city)
        {
            var exist = _context.Customers.Any(_ => _.CustomerCity == city);
            if (exist)
            {
                ViewBag.message = $"{city} sehrinde en az 1 tane musteri var.";
            }
            else
            {
                ViewBag.message = $"{city} sehrinde hic musteri yok.";
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public IActionResult DeleteCustomer(int id)
        {
            var values = _context.Customers.Find(id);
            _context.Customers.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            var values = _context.Customers.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        public IActionResult CustomerListByCity()
        {
            var groupedCustomers = _context.Customers.ToList().GroupBy(c => c.CustomerCity).ToList();
            return View(groupedCustomers);
        }
        public IActionResult CustomerByCityCount()
        {
            var query = from c in _context.Customers
                        group c by c.CustomerCity into cityGroup
                        select new CustomerCityGroup
                        {
                            City = cityGroup.Key,
                            CustomerCount = cityGroup.Count()
                        };
            var model = query.ToList();
            return View(model);
        }

        public IActionResult CustomerCityList()
        {
            var values = _context.Customers.Select(c => c.CustomerCity).Distinct().ToList();
            return View(values);
        }
        public IActionResult ParallelCustomers()
        {
            var customers = _context.Customers.ToList();
            var result = customers.AsParallel().Where(c => c.CustomerCity.StartsWith("L", StringComparison.OrdinalIgnoreCase)).ToList();
            return View(result);
        }

        public IActionResult CustomerListExceptCityLondon()
        {
            var allCustomers = _context.Customers.ToList();
            var customersListInLondon = _context.Customers.Where(c => c.CustomerCity == "London").ToList();
            var result = allCustomers.Except(customersListInLondon).ToList();
            return View(result);
        }

        public IActionResult CustomerListWithDefaultIfEmpty()
        {
            var customers = _context.Customers.Where(x => x.CustomerCity == "Liverpool").ToList().DefaultIfEmpty(new Customer
            {
                CustomerId = 0,
                CustomerName = "No Customer",
                CustomerSurname = "----",
                CustomerCity = "Liverpool",
            }).ToList();
            return View(customers);
        }

        public IActionResult CustomerIntersectByCity()
        {
            var cityValues1 = _context.Customers.Where(c => c.CustomerCity == "London").Select(y => y.CustomerName + " " + y.CustomerSurname).ToList();
            var cityValues2 = _context.Customers.Where(z => z.CustomerCity == "Liverpool").Select(t => t.CustomerName + " " + t.CustomerSurname).ToList();
            var intersectValues = cityValues1.Intersect(cityValues2).ToList();
            return View(intersectValues);
        }

        public IActionResult CustomerCastExample()
        {
            var values = _context.Customers.ToList();
            ViewBag.v = values;
            return View();
        }

        public IActionResult CustomerListWithIndex()
        {
            var customers = _context.Customers.ToList()
                .Select((c, index) => new
                {
                    SiraNo = index + 1,
                    c.CustomerName,
                    c.CustomerSurname,
                    c.CustomerCity
                }).ToList();
            return View(customers);
        }
    }
}