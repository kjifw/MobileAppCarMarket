namespace MobileCarMarket.ViewModels
{
    using MobileCarMarket.Helpers;

    public static class PublishViewModelValidator
    {
        public static bool Validate(PublishViewModel model)
        {
            if (model.Manufacturer == null)
            {
                Notification.Publish("Please select manufacturer.");
                return false;
            }

            if (model.Model == null)
            {
                Notification.Publish("Please select model.");
                return false;
            }

            if (model.Description == null)
            {
                Notification.Publish("Please fill description.");
                return false;
            }

            if (model.Price == 0)
            {
                Notification.Publish("Please fill price.");
                return false;
            }

            return true;
        }
    }
}
