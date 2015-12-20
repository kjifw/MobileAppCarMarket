namespace MobileCarMarket.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        public SearchViewModel()
        {

        }

        public SearchViewModel(SearchViewModel model)
            : this(model.Manufacturer, model.IsNew)
        {

        }

        public SearchViewModel(Manufacturer manufacturer, bool isNew)
        {
            this.Manufacturer = manufacturer;
            this.IsNew = isNew;
        }

        public Manufacturer Manufacturer { get; set; }

        public bool IsNew { get; set; }
    }
}
