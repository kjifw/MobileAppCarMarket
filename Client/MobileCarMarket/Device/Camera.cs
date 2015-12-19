namespace MobileCarMarket.Device
{
    using System;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Media.Capture;
    using Windows.Storage;
    using Windows.Storage.Streams;

    using SQLite.Net.Cipher.Interfaces;

    using LocalDb;
    using LocalDb.Models;
    using System.Threading.Tasks;
    public class Camera
    {
        public Camera()
        {

        }

        public async Task<byte[]> CapturePhotoAsBinaryBlob()
        {
            try
            {
                var cameraDialog = new CameraCaptureUI();
                var aspectRatio = new Size(16, 9);
                cameraDialog.PhotoSettings.CroppedAspectRatio = aspectRatio;

                StorageFile photoFile = await cameraDialog.CaptureFileAsync(CameraCaptureUIMode.Photo);

                if (photoFile == null)
                {
                    throw new InvalidOperationException("No photo captured");
                }

                using (IRandomAccessStream fileStream = await photoFile.OpenAsync(FileAccessMode.Read))
                {
                    var imageBlob = new byte[fileStream.Size];
                    await fileStream.ReadAsync(imageBlob.AsBuffer(), (uint)fileStream.Size, InputStreamOptions.None).AsTask();
                    await photoFile.DeleteAsync(StorageDeleteOption.PermanentDelete);

                    return imageBlob;
                }
            }
            catch
            {
                throw new InvalidOperationException("Please allow access to camera to be able to capture photo");
            }
        }
    }
}
