using MobileCarMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MobileCarMarket
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PublishPage : Page
    {
        public PublishPage()
        {
            this.InitializeComponent();

            var contentViewModel = new PublishContentViewModel();

            this.DataContext = new MainPageViewModel(contentViewModel);

            this.MyItems.Add(new MyItem() { Id = Guid.NewGuid(), Text = "Muhahah" });
            this.MyItemsTwo.Add(new MyItem() { Id = Guid.NewGuid(), Text = "Not so funny" });
        }

        public ObservableCollection<MyItem> MyItems { get; private set; } = new ObservableCollection<MyItem>();
        public ObservableCollection<MyItem> MyItemsTwo { get; private set; } = new ObservableCollection<MyItem>();

        private void listViewAllImages_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                e.AcceptedOperation = DataPackageOperation.Move;
            }
        }

        private async void listViewAllImages_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var id = await e.DataView.GetTextAsync();
                var itemIdsToMove = id.Split(',');

                var destinationListView = sender as ListView;
                var listViewItemsSource = destinationListView?.ItemsSource as ObservableCollection<MyItem>;

                if (listViewItemsSource != null)
                {
                    foreach (var itemId in itemIdsToMove)
                    {
                        var itemToMove = this.MyItems.FirstOrDefault(i => i.Id.ToString() == itemId);

                        if (itemToMove != null)
                        {
                            listViewItemsSource.Add(itemToMove);
                            this.MyItems.Remove(itemToMove);
                        }
                    }
                }
            }
        }

        private void listViewAllImages_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var items = string.Join(",", e.Items.Cast<MyItem>().Select(i => i.Id));
            e.Data.SetText(items);
            e.Data.RequestedOperation = DataPackageOperation.Move;
        }

        private void listViewUploadImages_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                e.AcceptedOperation = DataPackageOperation.Move;
            }
        }

        private async void listViewUploadImages_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var id = await e.DataView.GetTextAsync();
                var itemIdsToMove = id.Split(',');

                var destinationListView = sender as ListView;
                var listViewItemsSource = destinationListView?.ItemsSource as ObservableCollection<MyItem>;

                if (listViewItemsSource != null)
                {
                    foreach (var itemId in itemIdsToMove)
                    {
                        var itemToMove = this.MyItemsTwo.FirstOrDefault(i => i.Id.ToString() == itemId);

                        if (itemToMove != null)
                        {
                            listViewItemsSource.Add(itemToMove);
                            this.MyItemsTwo.Remove(itemToMove);
                        }
                    }
                }
            }
        }

        private void listViewUploadImages_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var items = string.Join(",", e.Items.Cast<MyItem>().Select(i => i.Id));
            e.Data.SetText(items);
            e.Data.RequestedOperation = DataPackageOperation.Move;
        }
    }
}
