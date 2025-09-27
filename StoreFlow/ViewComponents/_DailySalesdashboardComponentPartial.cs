using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Models;

namespace StoreFlow.ViewComponents
{
    public class _DailySalesdashboardComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;
        public _DailySalesdashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var data = _context.Todos
                .GroupBy(t => t.Priority)
                .Select(g => new TodoStatusChartViewModel
                {
                    Status = g.Key,
                    Count = g.Count()
                }).ToList();
            return View(data);
        }
    }
}
