namespace MobileCarMarket.ViewModels
{
    public static class PublishViewModelValidator
    {
        public static bool Validate(PublishViewModel model)
        {
            if(model.Manufacturer == null)
            {
                // Please select manufacturer
                return false;
            }

            if(model.Model == null)
            {
                // Please select model
                return false;
            }

            if(model.Description == null)
            {
                // Please fill description
                return false;
            }

            if(model.Price == 0)
            {
                // Please fill price
                return false;
            }

            return true;
        }
    }
}
