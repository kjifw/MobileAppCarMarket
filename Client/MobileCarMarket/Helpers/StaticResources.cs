namespace MobileCarMarket.Helpers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using ViewModels;

    public static class StaticResources
    {
        private static List<string> MercedesModels = new List<string>()
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

        private static List<string> AudiModels = new List<string>()
        {
            "A3",
            "A4",
            "A5",
            "A6",
            "A7",
            "Q3",
            "Q5",
            "Q7"
        };

        private static List<string> BmwModels = new List<string>()
        {
            "3 series",
            "4 series",
            "5 series",
            "6 series",
            "7 series",
            "X3",
            "X5",
            "X6"
        };

        public static ObservableCollection<Manufacturer> GetManufacturers()
        {
            var manufacturersToAdd = new ObservableCollection<Manufacturer>();

            manufacturersToAdd.Add(new Manufacturer()
            {
                Name = "Audi",
                Models = AudiModels
            });

            manufacturersToAdd.Add(new Manufacturer()
            {
                Name = "Bmw",
                Models = BmwModels
            });

            manufacturersToAdd.Add(new Manufacturer()
            {
                Name = "Mercedes",
                Models = MercedesModels
            });

            return manufacturersToAdd;
        }
    }
}
