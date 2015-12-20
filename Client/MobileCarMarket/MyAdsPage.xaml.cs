namespace MobileCarMarket
{
    using MobileCarMarket.ViewModels;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyAdsPage : Page
    {
        public MyAdsPage()
        {
            this.InitializeComponent();

            var contentViewModel = new MyAdsContentViewModel();

            this.DataContext = new MainPageViewModel(contentViewModel);
        }
    }
}
