namespace MobileCarMarket.ViewModels
{
    public class PublishViewModel
    {
        public PublishViewModel()
            : this(null, null, 0.0, string.Empty, false)
        {

        }

        public PublishViewModel(PublishViewModel model)
            : this(model.Manufacturer, model.Model, model.Price, model.Description, model.IsNew)
        {

        }

        public PublishViewModel(Manufacturer manufacturer, string model, double price, string description, bool isNew)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.Description = description;
            this.IsNew = isNew;
        }

        public Manufacturer Manufacturer { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public bool IsNew { get; set; }
    }
}