using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SignalRDemo.Controllers;

namespace SignalRDemo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private CompositionContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MefConfig.RegisterMef();
        }
    }


    /// <summary>
    /// Resolve dependencies for MVC / Web API using MEF.
    /// </summary>
    public class MefDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly CompositionContainer _container;

        public MefDependencyResolver(CompositionContainer container)
        {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        /// <summary>
        /// Called to request a service implementation.
        /// 
        /// Here we call upon MEF to instantiate implementations of dependencies.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Service implementation or null.</returns>
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            var name = AttributedModelServices.GetContractName(serviceType);
            var export = _container.GetExportedValueOrDefault<object>(name);
            return export;
        }

        /// <summary>
        /// Called to request service implementations.
        /// 
        /// Here we call upon MEF to instantiate implementations of dependencies.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Service implementations.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            var exports = _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
            return exports;
        }

        public void Dispose()
        {
        }
    }

    public static class MefConfig
    {
        public static void RegisterMef()
        {
            var aggregateCatalog = new AggregateCatalog();
            aggregateCatalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(aggregateCatalog);
            var resolver = new MefDependencyResolver(container);
            // Install MEF dependency resolver for MVC
            DependencyResolver.SetResolver(resolver);
            // Install MEF dependency resolver for Web API
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}