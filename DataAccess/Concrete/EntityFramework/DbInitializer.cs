using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public static class DbInitializer
    {
        public static void Initialize (TodoContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Todos.Any())
            {
                return; // DB has been seeded
            }
            var todos = new Todo[]
            {
                new Todo{TodoId=1,TodoDate=DateTime.Parse("2005-03-01"),TodoName="Daily work",TodoDetails="Details",CategoryName="Primary"},
                 new Todo{TodoId=2,TodoDate=DateTime.Parse("2006-06-01"),TodoName="Annual work",TodoDetails="Details",CategoryName="Primary"},
                  new Todo{TodoId=3,TodoDate=DateTime.Parse("2010-05-01"),TodoName="Weekly work",TodoDetails="Details",CategoryName="Secondary"},
                   new Todo{TodoId=4,TodoDate=DateTime.Parse("2015-05-01"),TodoName="Monthly work",TodoDetails="Details",CategoryName="Secondary"},
                    new Todo{TodoId=5,TodoDate=DateTime.Parse("2021-12-01"),TodoName="Secondary work",TodoDetails="Details",CategoryName="Secondary"},
            };
            foreach (Todo todo in todos)
            {
                context.Add(todo);
            }
            context.SaveChanges();

            var categories = new Category[]
            {
                new Category{CategoryId=1,CategoryName="Primary"},
                new Category{CategoryId=2,CategoryName="Secondary"}
            };

            foreach (Category category in categories)
            {
                context.Add(category);
            }
            context.SaveChanges();
        }
    }
}
