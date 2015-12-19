using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace MobileCarMarket.Helpers
{
    public static class Notification
    {
        public static void Publish(string message, int expiryTime = 20)
        {
            ToastNotificationManager.History.Clear();

            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            DateTimeOffset expireIn = DateTime.Now.AddSeconds(expiryTime);

            XmlNodeList toastElements = toastXml.GetElementsByTagName("text");

            toastElements[0].AppendChild(toastXml.CreateTextNode(message));

            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = expireIn;

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
