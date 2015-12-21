namespace MobileCarMarket.Helpers
{
    using System;
    using Windows.UI.Popups;

    public static class MessageBox
    {
        public static async void Show(string message)
        {
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync().AsTask();
        }
    }
}
