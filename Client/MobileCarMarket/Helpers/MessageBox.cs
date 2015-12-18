namespace MobileCarMarket.Helpers
{
    using Windows.UI.Popups;

    public static class MessageBox
    {
        public static void Show(string message)
        {
            var dialog = new MessageDialog(message);
            dialog.ShowAsync().GetResults();
        }
    }
}
