namespace MobileCarMarket
{
    using Windows.UI.Xaml.Controls;

    using Helpers;
    using ViewModels;

    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();

            var contentViewModel = new SearchContentViewModel();

            this.DataContext = new MainPageViewModel(contentViewModel);
            contentViewModel.Manufacturers = StaticResources.GetManufacturers();
        }
    }
}
