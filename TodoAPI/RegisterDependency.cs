using Business.Abstract;
using Business.Concrete;
using Core.Helpers;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace TodoAPI
{
    public static class RegisterDependency
    {
        public static void RegisterDependencies(this IServiceCollection services) 
        {
            services.AddDbContext<TodoContext>(options => options.UseSqlServer(AppSettingsHelper.GetValue("SqlServerConnectionString",""),
                b => b.MigrationsAssembly("TodoAPI")));

            services.AddScoped<IToDoService,ToDoManager>();
            services.AddScoped<ITodoDal,TodoDal>();

            services.AddScoped<IUserService,UserManager>();
            services.AddScoped<IUserDal,UserDal>();

            services.AddScoped<ICategoryDal,CategoryDal>();            

        }
    }
}
