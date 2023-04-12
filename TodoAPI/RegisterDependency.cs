using Business.Abstract;
using Business.Concrete;
using Core.Aspects.Log;
using Core.Helpers;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TodoAPI
{
    public static class RegisterDependency
    {
        public static void RegisterDependencies(this IServiceCollection services) 
        {
            services.AddScoped(typeof(ILog<>),typeof(Logger<>));

            services.AddDbContext<TodoContext>(options => options.UseSqlServer(AppSettingsHelper.GetValue("SqlServerConnectionString",""),
                b => b.MigrationsAssembly("TodoAPI")));

            services.AddScoped<IToDoService,ToDoManager>();
            services.AddScoped<ITodoDal,TodoDal>();

            services.AddScoped<IUserService,UserManager>();
            services.AddScoped<IUserDal,UserDal>();

            services.AddScoped<ICategoryDal,CategoryDal>();            
            services.AddScoped<ICategoryService,CategoryManager>();            

        }
    }
}
