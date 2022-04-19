using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    internal class ModelConfiguration : DbContext
    {
        //public ModelConfiguration(DbContextOptions options) : base(options)
        //{
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Todo>().HasMany(c=>c.TodoDetails)..HasOne(c=>c.Category).ToTable("Todos").HasKey(t=>t.Id);

            modelBuilder.Entity<Category>().ToTable("Categories");

        }
    }
}
