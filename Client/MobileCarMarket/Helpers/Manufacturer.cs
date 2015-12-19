namespace MobileCarMarket.Helpers
{
    using System.Collections.Generic;

    public class Manufacturer
    {
        public Manufacturer(string name)
        {
            this.Name = name;
            this.Models = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Models { get; set; }
    }
}
