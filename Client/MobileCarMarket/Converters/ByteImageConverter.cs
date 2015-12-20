namespace MobileCarMarket.Converters
{
    using System;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;

    public static class ByteImageConverter
    {
        public static async Task<ImageSource> ByteToImage(byte[] imageData)
        {
            var randomAccessStream = await ByteImageConverter.ByteToRandomAccessStream(imageData);

            BitmapImage biImg = new BitmapImage();
            biImg.SetSource(randomAccessStream);

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        public static async Task<IRandomAccessStream> ByteToRandomAccessStream(byte[] imageData)
        {
            InMemoryRandomAccessStream randomAccessStream = new InMemoryRandomAccessStream();
            await randomAccessStream.WriteAsync(imageData.AsBuffer());
            randomAccessStream.Seek(0);

            return randomAccessStream;
        }
    }
}
