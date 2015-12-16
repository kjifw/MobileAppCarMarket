namespace MobileCarMarket.ViewModels
{
    using System.Collections.ObjectModel;

    public class FavouritesContentViewModel : ViewModelBase, IContentViewModel
    {
        private ObservableCollection<FavouritesViewModel> favouritesList;

        public ObservableCollection<FavouritesViewModel> FavouritesList
        {
            get
            {
                if (this.favouritesList == null)
                {
                    this.favouritesList = new ObservableCollection<FavouritesViewModel>();
                }

                return this.favouritesList;
            }
            set
            {
                if (this.favouritesList == null)
                {
                    this.favouritesList = new ObservableCollection<FavouritesViewModel>();
                }

                this.favouritesList.Clear();
                foreach (var item in value)
                {
                    this.favouritesList.Add(item);
                }
            }
        }
    }
}
