using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IToDoService>().As<ToDoManager>().SingleInstance();
            builder.RegisterType<ITodoDal>().As<TodoDal>().SingleInstance();

            builder.RegisterType<ICategoryService>().As<CategoryManager>().SingleInstance();
            builder.RegisterType<ICategoryDal>().As<CategoryDal>().SingleInstance();
                        
            builder.RegisterGeneric(typeof(Logger<>)).As<ILogger>().InstancePerLifetimeScope(); // needs to be tested
        }
    }
}
