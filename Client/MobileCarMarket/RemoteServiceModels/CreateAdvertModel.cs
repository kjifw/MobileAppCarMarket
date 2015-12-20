namespace MobileCarMarket.RemoteServiceModels
{
    public class CreateAdvertModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsNew { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
    }
}
