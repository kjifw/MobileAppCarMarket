using System;

namespace MobileCarMarket.ViewModels
{
    public class SearchResult
    {
        public SearchResult(string manufacturer, string model, double price, string imageUrl)
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