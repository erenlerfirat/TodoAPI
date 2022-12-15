﻿using Core.Entity.Concrete;
using Core.Helpers;
using DataAccess.Concrete.EntityFramework.Mapping;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class TodoContext : DbContext
    {
        public TodoContext()
        {

        }
        public TodoContext(DbContextOptions options) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {/*AppSettingsHelper.GetValue("SqlServerConnectionString","")*/
                optionsBuilder
               .UseSqlServer("Server=DG-FERENLER\\SQLEXPRESS;database=Todo;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True",
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
    }
}
