namespace MobileCarMarket.Data
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class MobileCarMarketDbContext : IdentityDbContext<User>, IMobileCarMarketDbContext
    {
        public MobileCarMarketDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                        .HasMany<Advert>(u => u.FavouriteAdverts)
                        .WithMany(a => a.FavouritedByUsers)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("UserId");
                            cs.MapRightKey("AdvertId");
                            cs.ToTable("FavouritedUsersAdverts");
                        });
        }

        public static MobileCarMarketDbContext Create()
        {
            return new MobileCarMarketDbContext();
        }
    }
}
