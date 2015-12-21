namespace MobileCarMarket.Services.Data
{
    using System.Linq;

    using MobileCarMarket.Models;
    using MobileCarMarket.Services.Data.Contracts;
    using MobileCarMarket.Data.Repositories;
    using Common.Utilities;

    public class AdvertsService : IAdvertsService
    {
        private IGenericRepository<User> users;
        private IGenericRepository<Advert> adverts;

        public AdvertsService(IGenericRepository<User> users, IGenericRepository<Advert> adverts)
        {
            this.users = users;
            this.adverts = adverts;
        }

        public Advert CreateAdvert(CreateAdvertData advertData)
        {
            var advert = new Advert()
            {
                Make = advertData.Make,
                Model = advertData.Model,
                IsNew = advertData.IsNew,
                Price = advertData.Price,
                PublishDate = advertData.PublishDate,
                UserId = advertData.UserId,
                Description = advertData.Description
            };

            this.adverts.Add(advert);
            this.adverts.SaveChanges();

            return advert;
        }

        public IQueryable<Advert> GetAdvertDetails(int id)
        {
            return this.adverts.All()
                .Where(a => a.Id == id);
        }

        public IQueryable<Advert> GetAdvertsOfUser(string userId)
        {
            return this.adverts.All()
                .Where(a => a.UserId == userId);
        }

        public bool AddImageToAdvert(int id, string userId, string imageUrl)
        {
            var advert = this.adverts.All()
                .Where(a => a.Id == id && a.UserId == userId)
                .FirstOrDefault();

            if(advert == null)
            {
                return false;
            }

            var imageData = new ImageData()
            {
                Url = imageUrl
            };

            if (advert.FirstImageData == null)
            {
                advert.FirstImageData = imageData;
            }

            advert.ImagesData.Add(imageData);
            this.adverts.SaveChanges();

            return true;
        }

        public bool AddAdvertToUserFavourites(int id, string userId)
        {
            return true;
        }

        public bool DeleteAdvert(int id, string userId)
        {
            var advert = this.adverts.All()
                .Where(a => a.Id == id && a.UserId == userId)
                .FirstOrDefault();

            if(advert == null)
            {
                return false;
            }

            advert.IsDeleted = true;
            this.adverts.SaveChanges();

            return true;
        }

        public IQueryable<Advert> GetAdvertsByFilters(string make, string model, bool onlyNew)
        {
            var predicate = PredicateBuilder.True<Advert>();

            predicate = predicate.And<Advert>(a => a.IsDeleted == false);
            predicate = predicate.And<Advert>(a => a.IsNew == onlyNew);

            if(make != null)
            {
                predicate = predicate.And<Advert>(a => a.Make == make);
            }

            if(model != null)
            {
                predicate = predicate.And<Advert>(a => a.Model == model);
            }

            return this.adverts.All()
                .Where(predicate);
        }
    }
}
