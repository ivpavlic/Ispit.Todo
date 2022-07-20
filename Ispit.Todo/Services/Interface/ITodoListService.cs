using Ispit.Todo.Models.Binding;
using Ispit.Todo.Models.ViewModel;

namespace Ispit.Todo.Services.Interface
{
    public interface ITodoListService
    {
        Task<TodoListViewModel> AddTodoListAsync(TodoListBinding model);
        Task<List<TodoListViewModel>> GetTodoListsAsync();
        Task<List<ApplicationUserViewModel>> GetApplicationUsersAsync();

        Task<TaskViewModel> AddTaskAsync(TaskDataBinding model);
        Task<List<TaskViewModel>> GetTasksAsync();
        Task<List<TodoListViewModel>> GetTodoListAsync();
    }
}