namespace MobileCarMarket.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using System.Collections.Generic;

    public class User : IdentityUser
    {
        private ICollection<Advert> favouriteAdverts;
        private ICollection<Advert> publishedAdverts;

        public User()
        {
            this.favouriteAdverts = new HashSet<Advert>();
            this.publishedAdverts = new HashSet<Advert>();
        }
        
        public virtual ICollection<Advert> FavouriteAdverts
        {
            get { return this.favouriteAdverts; }
            set { this.favouriteAdverts = value; }
        } 

        public virtual ICollection<Advert> PublishedAdverts
        {
            get { return this.publishedAdverts; }
            set { this.publishedAdverts = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            return userIdentity;
        }
    }
}