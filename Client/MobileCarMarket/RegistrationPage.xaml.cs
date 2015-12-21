namespace MobileCarMarket
{
    using Windows.UI.Xaml.Controls;

    using ViewModels;

    public sealed partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            this.InitializeComponent();

            var contentViewModel = new RegistrationContentViewModel();
            this.DataContext = new MainPageViewModel(contentViewModel);
        }
    }
}
