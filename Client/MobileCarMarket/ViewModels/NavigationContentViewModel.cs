namespace MobileCarMarket.ViewModels
{
    using Helpers;
    using System.Windows.Input;

    public class NavigationContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand searchCommand;
        private ICommand publishCommand;
        private ICommand favouritesCommand;
        private ICommand viewMyAdsCommand;

        public ICommand SearchCommand
        {
            get
            {
                if (this.searchCommand == null)
                {
                    this.searchCommand = new DelegateCommand(() =>
                    {

                    });
                }

                return this.searchCommand;
            }
        }

        public ICommand PublishCommand
        {
            get
            {
                if (this.publishCommand == null)
                {
                    this.publishCommand = new DelegateCommand(() =>
                    {

                    });
                }

                return this.publishCommand;
            }
        }

        public ICommand FavouritesCommand
        {
            get
            {
                if (this.favouritesCommand == null)
                {
                    this.favouritesCommand = new DelegateCommand(() =>
                    {

                    });
                }

                return this.favouritesCommand;
            }
        }

        public ICommand ViewMyAdsCommand
        {
            get
            {
                if (this.viewMyAdsCommand == null)
                {
                    this.viewMyAdsCommand = new DelegateCommand(() =>
                    {

                    });
                }

                return this.viewMyAdsCommand;
            }
        }
    }
}
