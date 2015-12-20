using Microsoft.Owin;
using Owin;
using System.Web.Http;

using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

using MobileCarMarket.Web.Api.App_Start;
using MobileCarMarket.Common.Constants;
using MobileCarMarket.Web.Api.Models.Adverts;
using MobileCarMarket.Services.Data.Contracts;

[assembly: OwinStartup(typeof(MobileCarMarket.Web.Api.Startup))]

namespace MobileCarMarket.Web.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutoMapper.Mapper.CreateMap<CreateAdvertRequestModel, CreateAdvertData>();
            AutoMapperConfig.RegisterMappings(Assemblies.WebApi);

            ConfigureAuth(app);

            var httpConfig = new HttpConfiguration();

            WebApiConfig.Register(httpConfig);

            httpConfig.EnsureInitialized();

            app
                .UseNinjectMiddleware(NinjectConfig.CreateKernel)
                .UseNinjectWebApi(httpConfig);
        }
    }
}
