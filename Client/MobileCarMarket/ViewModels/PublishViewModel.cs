namespace MobileCarMarket.ViewModels
{
    using Helpers;
    using System;
    using System.Collections.Generic;

    public class PublishViewModel
    {
        public PublishViewModel()
            : this(null, 0.0, string.Empty, false, null)
        {
        }

        public PublishViewModel(PublishViewModel model)
            : this(model.Manufacturer, model.Price, model.Description, model.Used, model.ImageUrl)
        {
        }

        public PublishViewModel(Manufacturer manufacturer, double price, string description, bool used, Uri imageUrl)
        {
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Description = description;
            this.Used = used;
            this.ImageUrl = imageUrl;
        }

        public Manufacturer Manufacturer { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public bool Used { get; set; }

        public Uri ImageUrl { get; set; }
    }
}