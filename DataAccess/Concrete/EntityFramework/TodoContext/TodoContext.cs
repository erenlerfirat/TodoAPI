using Core.Entity.Concrete;
using DataAccess.Concrete.EntityFramework.Mapping;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.Concrete.EntityFramework
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }
        public TodoContext() 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                throw new NotImplementedException("idiot");
            }
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseSqlServer(
                   @"Server=ISTN37241;database=Todo;Trusted_Connection=True;MultipleActiveResultSets=True",
                   providerOptions => { providerOptions.EnableRetryOnFailure(5); });
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoMapping());
            modelBuilder.ApplyConfiguration(new TodoDetailMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            
        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TodoDetail> TodoDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
