using System.Web.Http;
using ShreyCart.Abstractions;
using ShreyCart.Business;
using ShreyCart.Common;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace ShreyCart.Service
{
    public class IocConfig
    {
        public static void ResolveDependencies()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IDataSource, CsvDataSource>(Lifestyle.Scoped);
            container.Register<IConfig, CartConfig>(Lifestyle.Scoped);
            container.Register<IProductContext, ProductContext>(Lifestyle.Scoped);
            container.Register<IBasketContext, BasketContext>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}