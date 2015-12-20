namespace MobileCarMarket
{
    using MobileCarMarket.ViewModels;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
