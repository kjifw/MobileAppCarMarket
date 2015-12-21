namespace MobileCarMarket
{
    using System;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

    using ViewModels;
    using Gestures;
    
    public sealed partial class RegistrationPage : Page
    {
        private bool swipeLeft;
        private bool swipeRight;
        private Type swipeLeftPage = typeof(MainPage);
        private Type swipeRightPage = null;

        public RegistrationPage()
        {
            this.InitializeComponent();

            var contentViewModel = new RegistrationContentViewModel();
            this.DataContext = new MainPageViewModel(contentViewModel);
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
