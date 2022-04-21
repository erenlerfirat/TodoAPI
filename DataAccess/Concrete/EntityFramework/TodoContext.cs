using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=ISTN37241;database=Todo;Trusted_Connection=True;MultipleActiveResultSets=True",
                    providerOptions => { providerOptions.EnableRetryOnFailure(5); });
        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TodoDetail> TodoDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasKey(t => t.Id).IsClustered(true);
            modelBuilder.Entity<Todo>().HasMany(t => t.TodoDetails);
            modelBuilder.Entity<Todo>().HasOne(t => t.Category).WithMany(c => c.Todos)
                .HasForeignKey(t => t.CategoryId).HasPrincipalKey(t => t.Id);
            //modelBuilder.Entity<Todo>().HasIndex(t => t.CategoryId).IsUnique();

            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().ToTable("Categories");

            modelBuilder.Entity<TodoDetail>();
            modelBuilder.Entity<TodoDetail>().HasKey(d => d.Id);
            
            
        }
        
    }
}
