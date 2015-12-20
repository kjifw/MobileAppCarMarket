namespace MobileCarMarket.Services.Data
{
    using System;
    using System.Net.Http;
    using System.IO;
    using System.Drawing;
    using System.Threading.Tasks;

    using Contracts;
    using MobileCarMarket.Common.Utilities;

    public class ImagesService : IImagesService
    {
        private readonly Random random = new Random(DateTime.Now.Millisecond);

        public async Task<bool> StoreImage(HttpContent content, string path, int advertId, string userId)
        {
            Stream stream = await content.ReadAsStreamAsync();

            try
            {
                Image image = Image.FromStream(stream);
                var extension = ImageFormatUtils.FileExtensionFromEncoder(image.RawFormat);
                var testName = content.Headers.ContentDisposition.Name;
                var fileName = string.Format("{0}{1}{2}{3}.{4}", advertId, userId, DateTime.Now.Ticks, random.Next() % 10000007, extension);
                var fullPath = Path.Combine(path, fileName);
                image.Save(fullPath);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
