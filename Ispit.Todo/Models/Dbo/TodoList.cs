using Ispit.Todo.Models.Base;
using Ispit.Todo.Models.Dbo.Base;
using System.ComponentModel.DataAnnotations;

namespace Ispit.Todo.Models.Dbo
{
    public class TodoList : TodoListBase, IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public ICollection<TaskData> Tasks { get; set; }
        public ApplicationUser User { get; set; }
    }
}
