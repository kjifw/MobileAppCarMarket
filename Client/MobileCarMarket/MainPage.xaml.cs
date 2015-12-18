namespace MobileCarMarket
{
    using Windows.UI.Xaml.Controls;

    using ViewModels;

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var contentViewModel = new StartUpContentViewModel();
            this.DataContext = new MainPageViewModel(contentViewModel);
        }

        private void navigateToNavigationPage_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }
    }
}
