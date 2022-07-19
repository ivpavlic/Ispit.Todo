namespace Ispit.Todo.Models.Base
{
    public abstract class TaskDataBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
