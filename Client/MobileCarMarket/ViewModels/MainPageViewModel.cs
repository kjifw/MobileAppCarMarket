namespace MobileCarMarket.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IPageViewModel
    {
        public MainPageViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
        }

        public string Title
        {
            get
            {
                return "Mobile Car Market";
            }
        }

        public IContentViewModel ContentViewModel { get; set; }
    }
}
