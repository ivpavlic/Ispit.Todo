using Ispit.Todo.Data;
using Ispit.Todo.Models;
using Ispit.Todo.Models.Binding;
using Ispit.Todo.Models.Dbo;
using Ispit.Todo.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ispit.Todo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITodoListService todoListService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context, ITodoListService todoListService, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            this.context = context;
            this.todoListService = todoListService;
            this.userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TodoList()
        {
            var todoLists = await todoListService.GetTodoListsAsync();
            return View(todoLists);
        }

        [HttpGet]
        public async Task<IActionResult> AddTodoList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTodoList(TodoListBinding model)
        {
            await todoListService.AddTodoListAsync(model);
            return RedirectToAction("TodoList");
        }

        [HttpGet]
        public async Task<IActionResult> Task(int todoId)
        {
            var tasks = await todoListService.GetTasksAsync();
            return View(tasks);
        }

        [HttpGet]
        public async Task<IActionResult> AddTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskDataBinding model)
        {
            await todoListService.AddTaskAsync(model);
            return RedirectToAction("Task");
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Task == null)
            {
                return NotFound();
            }

            var book = await context.Task.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Created,Name,Description,Status")] TaskData task)
        {
            context.Update(task);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Task));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}