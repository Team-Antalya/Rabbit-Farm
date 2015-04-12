using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using System.Reflection;
using RabbitFarm.Data;
using RabbitFarm.WebAPI.Infrastructure;

[assembly: OwinStartup(typeof(RabbitFarm.WebAPI.Startup))]

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
