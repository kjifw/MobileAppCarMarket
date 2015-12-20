﻿namespace MobileCarMarket
{
    using MobileCarMarket.ViewModels;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();

            var contentViewModel = new SearchContentViewModel();

            this.DataContext = new MainPageViewModel(contentViewModel);
        }
    }
}
