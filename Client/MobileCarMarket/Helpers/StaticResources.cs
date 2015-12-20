namespace MobileCarMarket.Helpers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using ViewModels;

    public static class StaticResources
    {
        private static List<string> MercedezModels = new List<string>()
        {
            "A class",
            "B class",
            "C class",
            "S class",
            "CLS",
            "CLR",
            "CLA",
            "G class",
            "ML"
        };

        public static ObservableCollection<Manufacturer> GetManufacturers()
        {
            var manufacturersToAdd = new ObservableCollection<Manufacturer>();

            manufacturersToAdd.Add(new Manufacturer()
            {
                Name = "Mercedes",
                Models = MercedezModels
            });

            manufacturersToAdd.Add(new Manufacturer()
            {
                Name = "Mercedes",
                Models = MercedezModels
            });

            manufacturersToAdd.Add(new Manufacturer()
            {
                Name = "Mercedes",
                Models = MercedezModels
            });

            return manufacturersToAdd;
        }
    }
}
