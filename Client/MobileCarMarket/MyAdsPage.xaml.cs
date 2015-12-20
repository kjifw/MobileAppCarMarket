namespace MobileCarMarket
{
    using System.Collections.Generic;
    using Windows.UI.Xaml.Controls;
    using System.Collections.ObjectModel;
    using Windows.UI.Xaml.Navigation;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using ViewModels;
    using Http;
    using LocalDb;
    using LocalDb.Models;
    using RemoteServiceModels;

    public sealed partial class MyAdsPage : Page
    {
        private MyAdsContentViewModel contentViewModel;

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
