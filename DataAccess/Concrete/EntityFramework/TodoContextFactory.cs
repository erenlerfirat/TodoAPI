using Core.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.Concrete.EntityFramework
{
    public class TodoContextFactory : IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=DG-FERENLER\\SQLEXPRESS;database=Todo;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";

            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlServer(connectionString);

            return new TodoContext(optionsBuilder.Options);
        }
    }
}
