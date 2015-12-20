namespace MobileCarMarket.Web.Api.Controllers
{
    using System.Net.Http;
    using System.Web.Hosting;
    using System.Web.Http;
    using System.Threading.Tasks;

    using Services.Data.Contracts;
    using Common.Constants;

    [Authorize]
    public class ImagesController : ApiController
    {
        private IImagesService imagesService;

        public ImagesController(IImagesService imagesService)
        {
            this.imagesService = imagesService;
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
            var result = await this.imagesService.StoreImage(provider.Contents[0], HostingEnvironment.MapPath(GlobalConstants.ImagesStoreLocation), advertId, "");
            
            if(result == false)
            {
                return this.BadRequest();
            }

            return this.Created(string.Format("/api/images/{0}", advertId, longitude, latitude), "");
        }
    }
}
