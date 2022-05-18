using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class TodoDbContextDesignTimeFactory : IDesignTimeDbContextFactory<TodoContext>
    {   
        /// <summary>
        /// Creates and return DbContext in Design time for ef core transactions 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public TodoContext CreateDbContext(string[] args)
        {
            var context = new TodoContext();
            return context;
        }
    }
}
