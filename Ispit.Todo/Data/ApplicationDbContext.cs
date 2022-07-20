using Ispit.Todo.Models.Dbo;
using Ispit.Todo.Models.Dbo.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ispit.Todo.Models.ViewModel;

namespace Ispit.Todo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public override int SaveChanges()
        {

            var entries = ChangeTracker
                        .Entries()
                        .Where(e => e.Entity is IEntityBase && (
                          e.State == EntityState.Added
                          || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        ((IEntityBase)entityEntry.Entity).Created = DateTime.Now;
                        break;
                    default:
                        break;
                }

            }
            return base.SaveChanges();

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IEntityBase && (
              e.State == EntityState.Added
              || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        ((IEntityBase)entityEntry.Entity).Created = DateTime.Now;
                        break;
                    default:
                        break;
                }

            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string role = "admin";
            string userName = "admin@admin.com";
            //string roleId = Guid.NewGuid().ToString();
            //string userId = Guid.NewGuid().ToString();

            string roleId = "d6b5b0da-e61e-46ba-b766-e1acc7401352";
            string userId = "badd4ddd-df0e-4621-af37-c2b36aaa6742";


            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = role,
                NormalizedName = "ADMIN",
                Id = roleId
            });
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                UserName = userName,
                Email = userName,
                NormalizedUserName = userName.ToUpper(),
                NormalizedEmail = userName.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password12345"),
                //SecurityStamp = Guid.NewGuid().ToString("D"),
                SecurityStamp = "c8c5cc23-1703-4984-8ac7-4b178d2d9982",
                Firstname = "Ivan",
                Lastname = "Pavlić"

            });


            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });

        }


        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<TodoList> TodoList { get; set; }
        public DbSet<TaskData> Task { get; set; }
        public DbSet<Ispit.Todo.Models.ViewModel.TodoListViewModel>? TodoListViewModel { get; set; }
        public DbSet<Ispit.Todo.Models.ViewModel.TaskViewModel>? TaskViewModel { get; set; }

    }
}