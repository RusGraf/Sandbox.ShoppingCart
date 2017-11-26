using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.WebHost;
using Sandbox.ShoppingCart.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sandbox.ShoppingCart
{
    public class Global : NinjectHttpApplication
    {
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //}

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //RegisterDependencies();
        }

        protected override IKernel CreateKernel()
        {
            //var kernel = new StandardKernel();
            //kernel.Load(Assembly.GetExecutingAssembly());

            //return kernel;

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return BootstrapHelper.LoadNinjectKernel(assemblies);
        }
    }

    public interface INinjectModuleBootstrapper
    {
        IList<INinjectModule> GetModules();
    }

    public class DataAccessBootstrapper : INinjectModuleBootstrapper
    {
        public IList<INinjectModule> GetModules()
        {
            //this is where you will be considering priority of your modules.
            return new List<INinjectModule>()
                   {
                       new NinjectMapper()
                   };
            //RepositoryModule cannot be loaded until DataObjectModule is loaded
            //as it is depended on DataObjectModule and DbConnectionModule has
            //dependency on RepositoryModule
        }
    }

    public static class BootstrapHelper
    {
        public static StandardKernel LoadNinjectKernel(IEnumerable<Assembly> assemblies)
        {
            var standardKernel = new StandardKernel();
            foreach (var assembly in assemblies)
            {
                assembly
                    .GetTypes()
                    .Where(t =>
                           t.GetInterfaces()
                               .Any(i =>
                                    i.Name == typeof(INinjectModuleBootstrapper).Name))
                    .ToList()
                    .ForEach(t =>
                    {
                        var ninjectModuleBootstrapper =
                        (INinjectModuleBootstrapper)Activator.CreateInstance(t);

                        standardKernel.Load(ninjectModuleBootstrapper.GetModules());
                    });
            }
            return standardKernel;
        }
    }
}
