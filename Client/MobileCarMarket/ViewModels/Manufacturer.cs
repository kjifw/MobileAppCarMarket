namespace MobileCarMarket.ViewModels
{
    using System.Collections.Generic;

    public class Manufacturer
    {
        public string Name { get; set; }

        public ICollection<string> Models { get; set; }
    }
}
