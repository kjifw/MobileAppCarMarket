namespace MobileCarMarket.Services.Data.Contracts
{
    using System.Linq;

    using Models;

    public interface IAdvertsService
    {
        Advert CreateAdvert(CreateAdvertData advertData);

        IQueryable<Advert> GetAdvertDetails(int id);

        IQueryable<Advert> GetAdvertsOfUser(string userId);

        bool AddImageToAdvert(int id, string userId, string imageUrl);

        bool DeleteAdvert(int id, string userId);
             
        bool AddAdvertToUserFavourites(int id, string userId);

        IQueryable<Advert> GetAdvertsByFilters(string make, string model, bool onlyNew);
    }
}
