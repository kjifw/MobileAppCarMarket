namespace MobileCarMarket
{
    using System;
    using System.Collections.Generic;
    using Windows.UI.Xaml.Controls;
    using System.Collections.ObjectModel;
    using Windows.UI.Xaml.Navigation;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Input;

    using Newtonsoft.Json;

    using ViewModels;
    using Http;
    using LocalDb;
    using LocalDb.Models;
    using RemoteServiceModels;
    using Gestures;

    public sealed partial class MyAdsPage : Page
    {
        private MyAdsContentViewModel contentViewModel;
        private bool swipeLeft;
        private bool swipeRight;
        private Type swipeLeftPage = typeof(NavigationPage);
        private Type swipeRightPage = null;

        public MyAdsPage()
        {
            this.InitializeComponent();

            var contentViewModel = new MyAdsContentViewModel();
            this.DataContext = new MainPageViewModel(contentViewModel);
            this.contentViewModel = contentViewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            contentViewModel.MyAdsList = await LoadMyAdsFromServer();
        }

        private void Page_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            new ManipulationCompletedHandler().Execute(ref this.swipeLeft, ref this.swipeRight, this.swipeLeftPage, this.swipeRightPage, e);
        }

        private void Page_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            new ManipulationDeltaHandler().Execute(sender, e, ref this.swipeLeft, ref this.swipeRight);
        }

        public async Task<ICollection<MyAdsViewModel>> LoadMyAdsFromServer()
        {
            var myAds = new ObservableCollection<MyAdsViewModel>();

            var getMyAdsApiUrl = "http://localhost:60178/api/adverts";
            var storage = LocalStorage.GetInstance;
            var token = storage.SecureGetAll<Token>(LocalStorage.KeySeed)[storage.SecureGetCount<Token>() - 1];
            
            var httpJsonDownloader = new HttpDataDownloader(getMyAdsApiUrl, token.Data);
            var response = await httpJsonDownloader.DownloadJsonData();

            if(response.Succeeded == true)
            {
                var listedAdverts = JsonConvert.DeserializeObject<List<ListedAdvertModel>>(response.Result);

                foreach(var listedAdvert in listedAdverts)
                {
                    myAds.Add(new MyAdsViewModel()
                    {
                        Manufacturer = listedAdvert.Make,
                        Model = listedAdvert.Model,
                        Price = listedAdvert.Price,
                        ImageUrl = listedAdvert.ImageUrl
                    });
                }
            }

            return myAds;
        }
    }
}
