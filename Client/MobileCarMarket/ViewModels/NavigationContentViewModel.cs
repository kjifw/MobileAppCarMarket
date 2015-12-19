namespace MobileCarMarket.ViewModels
{
    using System;
    using System.Windows.Input;

    using SQLite.Net.Cipher.Interfaces;

    using Helpers;
    using LocalDb;
    using LocalDb.Models;
    using Device;

    public class NavigationContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand searchCommand;
        private ICommand publishCommand;
        private ICommand favouritesCommand;
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

        public ICommand FavouritesCommand
        {
            get
            {
                if (this.favouritesCommand == null)
                {
                    this.favouritesCommand = new DelegateCommand(() =>
                    {
                        new NavigationService().Navigate(typeof(FavouritesPage));
                    });
                }

                return this.favouritesCommand;
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
                            MessageBox.Show("Please allow geolocation service to be able to capture photo");
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

                                storage.SecureInsert<Photo>(photo, LocalStorage.KeySeed);
                            }
                        }   
                        catch
                        {
                            MessageBox.Show("Failed to capture photo, please check your camera and geolocator");
                        }
                    });
                }

                return this.takePhoto;
            }
        }
    }
}
