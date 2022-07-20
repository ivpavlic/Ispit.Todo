using Microsoft.AspNetCore.Identity;

namespace Ispit.Todo.Models.Dbo
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public ICollection<TodoList> TodoLists { get; set; }
    }
}
