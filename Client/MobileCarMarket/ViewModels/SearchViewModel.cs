using MobileCarMarket.Helpers;

namespace MobileCarMarket.ViewModels
{

    public class SearchViewModel : ViewModelBase
    {
        public SearchViewModel()
        {
        }

        public SearchViewModel(SearchViewModel model)
            : this(model.Manufacturer, model.Used)
        {
        }

        public SearchViewModel(Manufacturer manufacturer, bool used)
        {
            this.Manufacturer = manufacturer;
            this.Used = used;
        }

        public Manufacturer Manufacturer { get; set; }

        public bool Used { get; set; }
    }
}
