namespace MobileCarMarket.Web.Api
{
    using App_Start;
    using System.Web;
    using System.Web.Http;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
