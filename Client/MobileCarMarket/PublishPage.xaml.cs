namespace MobileCarMarket
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Windows.ApplicationModel.DataTransfer;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    using ViewModels;
    using Helpers;

    public sealed partial class PublishPage : Page
    {
        private PublishContentViewModel contentViewModel;

        public PublishPage()
        {
            this.InitializeComponent();

            var contentViewModel = new PublishContentViewModel();
            this.DataContext = new MainPageViewModel(contentViewModel);
            this.contentViewModel = contentViewModel;
            contentViewModel.Manufacturers = StaticResources.GetManufacturers();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ((this.DataContext as MainPageViewModel).ContentViewModel as PublishContentViewModel).LoadCapturedImages();
        }

        private void ImagesForPublishingListView_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                e.AcceptedOperation = DataPackageOperation.Move;
            }
        }

        private async void ImagesForPublishingListView_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var id = await e.DataView.GetTextAsync();
                var itemIdsToMove = id.Split(',');

                var destinationListView = sender as ListView;
                var listViewItemsSource = destinationListView?.ItemsSource as ObservableCollection<ImageView>;

                if (listViewItemsSource != null)
                {
                    foreach (var itemId in itemIdsToMove)
                    {
                        var itemToMove = this.contentViewModel.CapturedImages.FirstOrDefault(i => i.Id.ToString() == itemId);

                        if (itemToMove != null)
                        {
                            listViewItemsSource.Add(itemToMove);
                            this.contentViewModel.CapturedImages.Remove(itemToMove);
                        }
                    }
                }
            }
        }

        private void ImagesForPublishingListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var items = string.Join(",", e.Items.Cast<ImageView>().Select(i => i.Id));
            e.Data.SetText(items);
            e.Data.RequestedOperation = DataPackageOperation.Move;
        }

        private void CapturedImagesListView_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                e.AcceptedOperation = DataPackageOperation.Move;
            }
        }

        private async void CapturedImagesListView_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var id = await e.DataView.GetTextAsync();
                var itemIdsToMove = id.Split(',');

                var destinationListView = sender as ListView;
                var listViewItemsSource = destinationListView?.ItemsSource as ObservableCollection<ImageView>;

                if (listViewItemsSource != null)
                {
                    foreach (var itemId in itemIdsToMove)
                    {
                        var itemToMove = this.contentViewModel.ImagesForPublishing.FirstOrDefault(i => i.Id.ToString() == itemId);

                        if (itemToMove != null)
                        {
                            listViewItemsSource.Add(itemToMove);
                            this.contentViewModel.ImagesForPublishing.Remove(itemToMove);
                        }
                    }
                }
            }
        }

        private void CapturedImagesListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var items = string.Join(",", e.Items.Cast<ImageView>().Select(i => i.Id));
            e.Data.SetText(items);
            e.Data.RequestedOperation = DataPackageOperation.Move;
        }
    }
}
