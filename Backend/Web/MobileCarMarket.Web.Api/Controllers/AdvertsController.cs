namespace MobileCarMarket.Web.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using Models.Adverts;
    using Services.Data.Contracts;
    using Infrastructure.Validation;
    using AutoMapper.QueryableExtensions;

    [Authorize]
    public class AdvertsController : ApiController
    {
        private readonly IAdvertsService advertsService;

        public AdvertsController(IAdvertsService advertsService)
        {
            this.advertsService = advertsService;
        }

        [ValidateModel]
        public IHttpActionResult Post(CreateAdvertRequestModel createAdvertRequestModel)
        {
            var userId = this.User.Identity.GetUserId();

            var createAdvertData = AutoMapper.Mapper.Map<CreateAdvertData>(createAdvertRequestModel);
            createAdvertData.UserId = userId;
            createAdvertData.PublishDate = DateTime.UtcNow;

            var newAdvert = this.advertsService.CreateAdvert(createAdvertData);

            var advertResult = this.advertsService
                .GetAdvertDetails(newAdvert.Id)
                .ProjectTo<ListedAdvertResponseModel>()
                .FirstOrDefault();

            return this.Created(string.Format("/api/adverts/{0}", advertResult.Id), advertResult);
        }

        public IHttpActionResult Get(SearchAdvertsFiltersModel searchAdvertsFiltersModel)
        {
            var filteredResults = this.advertsService
                .GetAdvertsByFilters(searchAdvertsFiltersModel.Make, searchAdvertsFiltersModel.Model, searchAdvertsFiltersModel.IsNew)
                .ProjectTo<ListedAdvertResponseModel>()
                .ToList();

            return this.Ok<List<ListedAdvertResponseModel>>(filteredResults);
        }

        public IHttpActionResult GetAdvertsOfCurrentUser()
        {
            return this.Ok();
        }

        public IHttpActionResult GetFullAdvertInfoById(int id)
        {
            var advert = this.advertsService
                .GetAdvertDetails(id)
                .ProjectTo<AdvertResponseModel>()
                .FirstOrDefault();

            return this.Ok<AdvertResponseModel>(advert);
        }

        public IHttpActionResult Delete(int id)
        {
            return this.Ok();
        }
    }
}
