namespace MobileCarMarket
{
    using System;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Popups;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml;

    using ViewModels;
    using Helpers;
    
    public sealed partial class MainPage : Page
    {
        private bool swipeLeft;
        private bool swipeRight;

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
            if (this.swipeLeft || this.swipeRight)
            {
                e.Handled = true;

                bool process = false;

                if (this.swipeLeft)
                {
                    process = true;
                    var dialog = new MessageDialog("go to next page");
                    dialog.ShowAsync().GetResults();
                }

                if (this.swipeRight)
                {
                    process = true;
                    var dialog = new MessageDialog("go to previous page");
                    dialog.ShowAsync().GetResults();
                }

                if (process)
                {
                    //navigate
                }

                this.swipeLeft = false;
                this.swipeRight = false;
            }
        }

        private void Page_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var x = e.Cumulative.Translation.X;
            var y = e.Cumulative.Translation.Y;

            var xAb = Math.Abs(x);
            var yAb = Math.Abs(y);

            this.swipeLeft = false;
            this.swipeRight = false;

            // Ensure that the horizontal scroll is greater than the 
            // vertical scroll amount. 
            // In case the user swipes diagonally, ensure that the 
            // horizontal scroll is at least 5x bigger than the vertical
            // scroll to eliminate any accidental changes.

            if ((xAb > 10) && (xAb > (5 * yAb)))
            {
                if (x < y)
                {
                    e.Handled = true;
                    this.swipeLeft = false;
                    this.swipeRight = true;
                }
                else if (x > y)
                {
                    e.Handled = true;
                    this.swipeLeft = true;
                    this.swipeRight = false;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
