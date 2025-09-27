using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;

namespace StoreFlow.Controllers
{
    public class TodoController : Controller
    {
        private readonly StoreContext _context;

        public TodoController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateToDo()
        {
            var todos = new List<Todo>
            {
                new Todo { Description = "Send an e-mail.", Status = true, Priority = "Critical" },
                new Todo { Description = "Send a document.", Status = true, Priority = "High" },
                new Todo { Description = "Create a meeting.", Status = false, Priority = "Low" }
            };

            await _context.Todos.AddRangeAsync(todos);
            await _context.SaveChangesAsync();

            return View();
        }

        public IActionResult TodoAggreagatePriority()
        {
            var priorityFirstlyTodo = _context.Todos
                .Where(x => x.Priority == "Critical")
                .Select(y => y.Description)
                .ToList();

            string result = priorityFirstlyTodo.Aggregate((acc, desc) => acc + ", " + desc);
            ViewBag.results = result;
            return View();
        }

        public IActionResult IncompleteTask()
        {
            var values = _context.Todos.Where(x => !x.Status).Select(y => y.Description).ToList().Prepend("Gun basinda tum gorevleri knotrol etmeyi unutmayin!").ToList();
            return View(values);
        }

        public IActionResult TodoChunk()
        {
            var values = _context.Todos.Where(x => !x.Status).ToList().Chunk(2).ToList();
            return View(values);
        }

        public IActionResult TodoConcat()
        {
            var values = _context.Todos.Where(x => x.Priority == "Critical").ToList().Concat(_context.Todos.Where(y => y.Priority == "High")).ToList();
            return View(values);
        }
        public IActionResult TodoUnion()
        {
            var values = _context.Todos.Where(x => x.Priority == "Critical").ToList();
            var values2 = _context.Todos.Where(y => y.Priority == "High").ToList();
            var result = values.UnionBy(values2,x=>x.Description).ToList();
            return View(result);
        }
    }
}
