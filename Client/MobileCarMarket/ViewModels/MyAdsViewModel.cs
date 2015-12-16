namespace MobileCarMarket.ViewModels
{
    public class MyAdsViewModel
    {
        public MyAdsViewModel()
            : this(string.Empty, string.Empty, 0.0, string.Empty)
        {
        }

        public MyAdsViewModel(FavouritesViewModel model)
            : this(model.Manufacturer, model.Model, model.Price, model.ImageUrl)
        {
        }

        public MyAdsViewModel(string manufacturer, string model, double price, string imageUrl)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.ImageUrl = imageUrl;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }
    }
}