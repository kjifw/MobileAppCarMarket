namespace MobileCarMarket.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using System.Threading.Tasks;

    using SQLite.Net.Cipher.Interfaces;
    using Newtonsoft.Json;

    using Helpers;
    using LocalDb;
    using LocalDb.Models;
    using Converters;
    using Http;
    using RemoteServiceModels;
    using System.Net;
    public class PublishContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand publishCommand;

        private ObservableCollection<Manufacturer> manufacturers;
        private ObservableCollection<ImageView> capturedImages;
        private ObservableCollection<ImageView> imagesForPublishing;

        public async Task LoadCapturedImages()
        {
            var storage = LocalStorage.GetInstance;

            var imagesCount = storage.SecureGetCount<Photo>();

            if (imagesCount > 0)
            {
                var allImages = storage.SecureGetAll<Photo>(LocalStorage.KeySeed);
                var convertedAllImages = new ObservableCollection<ImageView>();

                foreach (var image in allImages)
                {
                    var imageView = new ImageView()
                    {
                        Id = image.Id,
                        Source = await ByteImageConverter.ByteToImage(image.Data)
                    };

                    convertedAllImages.Add(imageView);
                }

                this.CapturedImages = convertedAllImages;
            }
        }

        public ICommand PublishCommand
        {
            get
            {
                if (this.publishCommand == null)
                {
                    this.publishCommand = new DelegateCommandWithParameter<PublishViewModel>(async (model) =>
                    {
                        var isValidModel = PublishViewModelValidator.Validate(model);

                        if (isValidModel == false)
                        {
                            return;
                        }

                        if (this.ImagesForPublishing.Count == 0)
                        {
                            Notification.Publish("You can not publish advert without images.");
                            return;
                        }

                        var storage = LocalStorage.GetInstance;
                        var token = storage.SecureGetAll<Token>(LocalStorage.KeySeed)[storage.SecureGetCount<Token>() - 1];

                        var createAdvertApiUrl = "http://localhost:60178/api/adverts";
                        var advertId = await this.UploadAdvert(createAdvertApiUrl, token.Data, model);

                        if (advertId == null)
                        {
                            Notification.Publish("Failed to publish your advert.");
                            return;
                        }

                        var uploadAdvertImageApiUrl = string.Format("{0}{1}", "http://localhost:60178/api/images/", advertId);
                        var areImagesUploaded = await this.UploadImages(uploadAdvertImageApiUrl, token.Data, storage);

                        if (areImagesUploaded == false)
                        {
                            Notification.Publish("Failed to publish your advert.");
                            return;
                        }

                        Notification.Publish("Advert published.");
                        new NavigationService().Navigate(typeof(NavigationPage));
                    });
                }

                return this.publishCommand;
            }
        }

        public IEnumerable<Manufacturer> Manufacturers
        {
            get
            {
                if (this.manufacturers == null)
                {
                    this.manufacturers = new ObservableCollection<Manufacturer>();
                }

                return this.manufacturers;
            }

            set
            {
                if (this.manufacturers == null)
                {
                    this.manufacturers = new ObservableCollection<Manufacturer>();
                }

                this.manufacturers.Clear();

                foreach (var item in value)
                {
                    this.manufacturers.Add(item);
                }
            }
        }

        public ICollection<ImageView> CapturedImages
        {
            get
            {
                if (this.capturedImages == null)
                {
                    this.capturedImages = new ObservableCollection<ImageView>();
                }

                return this.capturedImages;
            }

            set
            {
                if (this.capturedImages == null)
                {
                    this.capturedImages = new ObservableCollection<ImageView>();
                }

                this.capturedImages.Clear();

                foreach (var item in value)
                {
                    this.capturedImages.Add(item);
                }
            }
        }

        public ICollection<ImageView> ImagesForPublishing
        {
            get
            {
                if (this.imagesForPublishing == null)
                {
                    this.imagesForPublishing = new ObservableCollection<ImageView>();
                }

                return this.imagesForPublishing;
            }

            set
            {
                if (this.imagesForPublishing == null)
                {
                    this.imagesForPublishing = new ObservableCollection<ImageView>();
                }

                this.imagesForPublishing.Clear();

                foreach (var item in value)
                {
                    this.imagesForPublishing.Add(item);
                }
            }
        }

        private async Task<bool> UploadImages(string apiUrl, string token, ISecureDatabase storage)
        {
            foreach (var imageForUpload in this.ImagesForPublishing)
            {
                var image = storage.SecureGet<Photo>(imageForUpload.Id, LocalStorage.KeySeed);

                var longitude = image.Longitude.ToString().Replace("-", "%2D");
                longitude = longitude.ToString().Replace(".", "%2E");

                var latitude = image.Latitude.ToString().Replace("-", "%2D");
                latitude = latitude.ToString().Replace(".", "%2D");

                var apiUrlWithCoordinates = string.Format("{0}/{1}/{2}", apiUrl, longitude, latitude);
                var httpImageUploader = new HttpDataUploader(apiUrlWithCoordinates, token);

                var imageStream = await ByteImageConverter.ByteToRandomAccessStream(image.Data);
                var result = await httpImageUploader.UploadImage(imageStream);

                if (result.Succeeded == false)
                {
                    return false;
                }
            }

            return true;
        }

        private async Task<int?> UploadAdvert(string apiUrl, string token, PublishViewModel model)
        {
            var httpAdvertUploader = new HttpDataUploader(apiUrl, token);

            var createAdvertModel = new CreateAdvertModel()
            {
                Make = model.Manufacturer.Name,
                Model = model.Model,
                Description = model.Description,
                IsNew = model.IsNew,
                Price = model.Price
            };

            var createAdvertModelSerialized = await Task.Factory.StartNew<string>(() =>
            {
                return JsonConvert.SerializeObject(createAdvertModel);
            });

            var response = await httpAdvertUploader.UploadJsonData(createAdvertModelSerialized);

            if (response.Succeeded == false)
            {
                return null;
            }

            var listedAdvertModel = await Task.Factory.StartNew<ListedAdvertModel>(() =>
            {
                return JsonConvert.DeserializeObject<ListedAdvertModel>(response.Result);
            });

            return listedAdvertModel.Id;
        }
    }
}
