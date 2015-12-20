namespace MobileCarMarket
{
    using MobileCarMarket.ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationPage : Page
    {
        public NavigationPage()
        {
            this.InitializeComponent();

            var contentViewModel = new NavigationContentViewModel();
            this.DataContext = new MainPageViewModel(contentViewModel);
        }

        private void PublishClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PublishPage));
        }

        private void MyAdsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyAdsPage));
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchPage));
        }

        private void TakePhoto(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchPage));
        }
    }
}
