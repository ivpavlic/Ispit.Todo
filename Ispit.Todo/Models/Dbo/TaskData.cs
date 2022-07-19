using Ispit.Todo.Models.Base;
using Ispit.Todo.Models.Dbo.Base;
using System.ComponentModel.DataAnnotations;

namespace Ispit.Todo.Models.Dbo
{
    public class TaskData : TaskDataBase, IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public TodoList TodoList { get; set; }
    }
}
