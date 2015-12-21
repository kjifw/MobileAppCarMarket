namespace MobileCarMarket.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        public SearchViewModel()
        {

        }

        public SearchViewModel(SearchViewModel model)
            : this(model.Manufacturer, model.IsNew, model.Model)
        {

        }

        public SearchViewModel(Manufacturer manufacturer, bool isNew, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.IsNew = isNew;
        }

        public Manufacturer Manufacturer { get; set; }

        public string Model { get; set; }

        public bool IsNew { get; set; }
    }
}
