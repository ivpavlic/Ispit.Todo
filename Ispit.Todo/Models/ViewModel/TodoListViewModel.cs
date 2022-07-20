using Ispit.Todo.Models.Base;

namespace Ispit.Todo.Models.ViewModel
{
    public class TodoListViewModel : TodoListBase
    {
        public string Id { get; set; }

        public ApplicationUserViewModel User { get; set; }
    }
}
