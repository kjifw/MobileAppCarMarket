namespace MobileCarMarket.Web.Api.App_Start
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MobileCarMarketDbContext, Configuration>());
        }
    }
}