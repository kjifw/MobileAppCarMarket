namespace MobileCarMarket.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class MyAdsContentViewModel : ViewModelBase, IContentViewModel
    {
        private ObservableCollection<MyAdsViewModel> myAdsList;

        public ICollection<MyAdsViewModel> MyAdsList
        {
            get
            {
                if (this.myAdsList == null)
                {
                    this.myAdsList = new ObservableCollection<MyAdsViewModel>();
                }

                return this.myAdsList;
            }
            set
            {
                if (this.myAdsList == null)
                {
                    this.myAdsList = new ObservableCollection<MyAdsViewModel>();
                }

                this.myAdsList.Clear();

                foreach (var item in value)
                {
                    this.myAdsList.Add(item);
                }
            }
        }
    }
}
