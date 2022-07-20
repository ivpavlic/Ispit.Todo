using AutoMapper;
using Ispit.Todo.Models.Binding;
using Ispit.Todo.Models.Dbo;
using Ispit.Todo.Models.ViewModel;

namespace Ispit.Todo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskDataBinding, TaskData>();
            CreateMap<TaskData, TaskViewModel>();
            CreateMap<TodoListBinding, TodoList>();
            CreateMap<TodoList, TodoListViewModel>();
            CreateMap<ApplicationUser, ApplicationUserViewModel>();
        }
    }
}

