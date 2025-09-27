using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _CardStatisticsDashboardComponentPartial : ViewComponent
    {
        private readonly StoreContext _storeContext;

        public _CardStatisticsDashboardComponentPartial(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.customerCount = _storeContext.Customers.Count();
            ViewBag.categoryCount = _storeContext.Categories.Count();
            ViewBag.productCount = _storeContext.Products.Count();
            ViewBag.averageCustomerBalance= _storeContext.Customers.Average(c => c.CustomerBalance);
            ViewBag.orderCount = _storeContext.Orders.Count();
            ViewBag.totalSales = _storeContext.Orders.Sum(o => o.TotalPrice);
            return View();
        }
    }
}
