namespace MobileCarMarket
{
    using System;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml;

    using ViewModels;
    using Helpers;
    using Gestures;

    public sealed partial class MainPage : Page
    {
        private bool swipeLeft;
        private bool swipeRight;
        private Type swipeLeftPage = null;
        private Type swipeRightPage = typeof(RegistrationPage);

        public MainPage()
        {
            this.InitializeComponent();

            var contentViewModel = new StartUpContentViewModel();
            this.DataContext = new MainPageViewModel(contentViewModel);
        }

        private void navigateToNavigationPage_Click(object sender, RoutedEventArgs e)
        {
            new NavigationService().Navigate(typeof(NavigationPage));
        }

        private void Page_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            new ManipulationCompletedHandler().Execute(ref this.swipeLeft, ref this.swipeRight, this.swipeLeftPage, this.swipeRightPage, e);
        }

        private void Page_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            new ManipulationDeltaHandler().Execute(sender, e, ref this.swipeLeft, ref this.swipeRight);
        }
    }
}
