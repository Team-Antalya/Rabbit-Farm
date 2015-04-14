using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using RabbitFarm.Data;
using RabbitFarm.WebAPI;
using RabbitFarm.WebAPI.Infrastructure;

[assembly: OwinStartup(typeof(Startup))]

namespace RabbitFarm.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IRabbitFarmData>().To<RabbitFarmData>().WithConstructorArgument("context", new RabbitFarmContext());
            kernel.Bind<IUserProvider>().To<AspNetUserProvider>();
        }
    }
}
