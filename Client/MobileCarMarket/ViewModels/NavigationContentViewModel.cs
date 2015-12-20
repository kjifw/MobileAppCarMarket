namespace MobileCarMarket.ViewModels
{
    using System;
    using System.Windows.Input;

    using SQLite.Net.Cipher.Interfaces;

    using Helpers;
    using LocalDb;
    using LocalDb.Models;
    using Device;
    using System.Threading.Tasks;

    public class NavigationContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand searchCommand;
        private ICommand publishCommand;
        private ICommand viewMyAdsCommand;
        private ICommand takePhoto;

        public ICommand SearchCommand
        {
            get
            {
                if (this.searchCommand == null)
                {
                    this.searchCommand = new DelegateCommand(() =>
                    {
                        new NavigationService().Navigate(typeof(SearchPage));
                    });
                }

                return this.searchCommand;
            }
        }

        public ICommand PublishCommand
        {
            get
            {
                if (this.publishCommand == null)
                {
                    this.publishCommand = new DelegateCommand(() =>
                    {
                        new NavigationService().Navigate(typeof(PublishPage));
                    });
                }

                return this.publishCommand;
            }
        }

        public ICommand ViewMyAdsCommand
        {
            get
            {
                if (this.viewMyAdsCommand == null)
                {
                    this.viewMyAdsCommand = new DelegateCommand(() =>
                    {
                        new NavigationService().Navigate(typeof(MyAdsPage));
                    });
                }

                return this.viewMyAdsCommand;
            }
        }

        public ICommand TakePhoto
        {
            get
            {
                if (this.takePhoto == null)
                {
                    this.takePhoto = new DelegateCommand(async () =>
                    {
                        var geolocation = new Geolocation();
                        var isGeolocatorAllowed = await geolocation.IsGeolocatorAllowed();

                        if (isGeolocatorAllowed == false)
                        {
                            Notification.Publish("Please allow geolocation service to be able to capture photo");
                            return;
                        }

                        try
                        {
                            var camera = new Camera();
                            var imageBlob = await camera.CapturePhotoAsBinaryBlob();
                            var coordinates = await geolocation.GetCoordinates();

                            using (ISecureDatabase storage = LocalStorage.GetInstance)
                            {
                                var photo = new Photo()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Data = imageBlob,
                                    Latitude = coordinates.Latitude,
                                    Longitude = coordinates.Longitude
                                };

                                await Task.Factory.StartNew<int>(() =>
                                {
                                    return storage.SecureInsert<Photo>(photo, LocalStorage.KeySeed);
                                });
                            }
                        }
                        catch
                        {
                            Notification.Publish("Failed to capture photo, please check your camera and geolocator.");
                        }
                    });
                }

                return this.takePhoto;
            }
        }
    }
}
