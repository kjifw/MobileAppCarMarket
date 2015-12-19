using MobileCarMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MobileCarMarket
{
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

        private void FavouritesClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FavouritesPage));
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
