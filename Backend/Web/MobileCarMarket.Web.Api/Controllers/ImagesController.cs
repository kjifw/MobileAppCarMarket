﻿namespace MobileCarMarket.Web.Api.Controllers
{
    using System;
    using System.Net.Http;
    using System.Web.Hosting;
    using System.Web.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    using Services.Data.Contracts;
    using Common.Constants;
    
    [Authorize]
    public class ImagesController : ApiController
    {
        private IImagesService imagesService;
        private IAdvertsService advertsService;

        public ImagesController(IImagesService imagesService, IAdvertsService advertsService)
        {
            this.imagesService = imagesService;
            this.advertsService = advertsService;
        }

        [Route("api/images/{advertId}/{longitude}/{latitude}")]
        public async Task<IHttpActionResult> Post(int advertId, string longitude, string latitude)
        {
            if (Request.Content.IsMimeMultipartContent() == false)
            {
                return this.BadRequest();
            }

            await Request.Content.LoadIntoBufferAsync();
            var provider = await Request.Content.ReadAsMultipartAsync(new MultipartMemoryStreamProvider());

            try
            {
                var fileName = await this.imagesService.StoreImage(provider.Contents[0], HostingEnvironment.MapPath(GlobalConstants.ImagesStoreLocation), advertId, "");
                var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
                var imageUrl = string.Format("{0}/images/{1}", baseUrl, fileName);

                var userId = this.User.Identity.GetUserId();

                this.advertsService.AddImageToAdvert(advertId, userId, imageUrl);
            }
            catch
            {
                return this.BadRequest();
            }

            return this.Created(string.Format("/api/images/{0}", advertId, longitude, latitude), "");
        }
    }
}
