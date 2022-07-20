using AutoMapper;
using Ispit.Todo.Data;
using Ispit.Todo.Models.Binding;
using Ispit.Todo.Models.Dbo;
using Ispit.Todo.Models.ViewModel;
using Ispit.Todo.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Todo.Services.Implementation
{
    public class TodoListService : ITodoListService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public TodoListService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        /// <summary>
        /// Dohvati sve todolist
        /// </summary>
        /// <returns></returns>
        public async Task<List<TodoListViewModel>> GetTodoListsAsync()
        {
            var dbo = await db.TodoList.ToListAsync();
            return dbo.Select(x => mapper.Map<TodoListViewModel>(x)).ToList();

        }

        /// <summary>
        /// Dodavanje nove toodo liste
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<TodoListViewModel> AddTodoListAsync(TodoListBinding model)
        {

            var user = await db.ApplicationUser.FirstOrDefaultAsync(x => x.Id == model.UserId);
            if (user == null)
            {
                return null;
            }

            var dbo = new TodoList
            {
                Name = model.Name,
                Description = model.Description,
                User = user
            };
            db.TodoList.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<TodoListViewModel>(dbo);

        }

        /// <summary>
        /// Dohvati sve taskove
        /// </summary>
        /// <returns></returns>
        public async Task<List<TaskViewModel>> GetTasksAsync()
        {
            var dbo = await db.Task
                .ToListAsync();
            return dbo.Select(x => mapper.Map<TaskViewModel>(x)).ToList();

        }

        /// <summary>
        /// Dodavanje nove toodo liste
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<TaskViewModel> AddTaskAsync(TaskDataBinding model)
        {

            var todoList = await db.TodoList.FirstOrDefaultAsync(x => x.Id == model.TodoListId);
            if (todoList == null)
            {
                return null;
            }

            var dbo = new TaskData
            {
                Name = model.Name,
                Description = model.Description,
                Status = model.Status,
                TodoList = todoList
            };
            db.Task.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<TaskViewModel>(dbo);

        }

        /// <summary>
        /// Dohvati sve todoList
        /// </summary>
        /// <returns></returns>
        public async Task<List<ApplicationUserViewModel>> GetApplicationUsersAsync()
        {
            var dbo = await db.ApplicationUser.ToListAsync();
            return dbo.Select(x => mapper.Map<ApplicationUserViewModel>(x)).ToList();


        }

        /// <summary>
        /// Dohvati sve todoListe
        /// </summary>
        /// <returns></returns>
        public async Task<List<TodoListViewModel>> GetTodoListAsync()
        {
            var dbo = await db.TodoList.ToListAsync();
            return dbo.Select(x => mapper.Map<TodoListViewModel>(x)).ToList();

        }
    }
}
