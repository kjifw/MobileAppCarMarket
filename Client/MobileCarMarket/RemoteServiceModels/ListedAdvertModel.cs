namespace MobileCarMarket.RemoteServiceModels
{
    using System;

    public class ListedAdvertModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsNew { get; set; }

        public double Price { get; set; }

        public DateTime PublishDate { get; set; }

        public string ImageUrl { get; set; }
    }
}
