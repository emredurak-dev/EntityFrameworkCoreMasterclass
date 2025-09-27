using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _ActivityDashboardComponentPartial : ViewComponent
    {
        private readonly StoreContext _storeContext;

        public _ActivityDashboardComponentPartial(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _storeContext.Activities.ToList();
            return View(values);
        }
    }
}
