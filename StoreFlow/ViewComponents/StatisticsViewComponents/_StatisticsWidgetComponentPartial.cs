using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents.StatisticsViewComponents
{
    public class _StatisticsWidgetComponentPartial : ViewComponent
    {
        private readonly StoreContext _storeContext;

        public _StatisticsWidgetComponentPartial(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.categoryCount = _storeContext.Categories.Count();
            ViewBag.productMaxPrice = _storeContext.Products.Max(x => x.ProductPrice);
            ViewBag.productMinPrice = _storeContext.Products.Min(x => x.ProductPrice);

            ViewBag.productMaxPriceItemName = _storeContext.Products.Where(x => x.ProductPrice == (_storeContext.Products.Max(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
            ViewBag.productMinPriceItemName = _storeContext.Products.Where(x => x.ProductPrice == (_storeContext.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();

            ViewBag.totalSumProductStock = _storeContext.Products.Sum(x => x.ProductStock);
            ViewBag.averageProductStock = _storeContext.Products.Average(x => x.ProductStock);
            ViewBag.averageProductPrice = _storeContext.Products.Average(_ => _.ProductPrice);

            ViewBag.biggerPriceThan50ProductCount = _storeContext.Products.Where(x => x.ProductPrice >= 50).Count();
            ViewBag.getIdIs4ProductName = _storeContext.Products.Where(x => x.ProductId == 4).Select(_ => _.ProductName).FirstOrDefault();
            ViewBag.productStockBiggerThan50SmallerThan100 = _storeContext.Products.Where(x => x.ProductStock > 50 && x.ProductStock < 100).Count();
            return View();
        }
    }
}
