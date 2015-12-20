namespace MobileCarMarket.Services.Data.Contracts
{
    using System;

    public class CreateAdvertData
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsNew { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public string UserId { get; set; }
    }
}
