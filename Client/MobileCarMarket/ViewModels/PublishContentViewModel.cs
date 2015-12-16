namespace MobileCarMarket.ViewModels
{
    using Helpers;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class PublishContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand publishCommand;
        private ObservableCollection<Manufacturer> manufacturers;

        public ICommand PublishCommand
        {
            get
            {
                if (this.publishCommand == null)
                {
                    this.publishCommand = new DelegateCommandWithParameter<PublishViewModel>((model) =>
                    {

                    });
                }

                return this.publishCommand;
            }
        }

        public IEnumerable<Manufacturer> Manufacturers
        {
            get
            {
                if (this.manufacturers == null)
                {
                    this.manufacturers = new ObservableCollection<Manufacturer>();
                }

                return this.manufacturers;
            }
            set
            {
                if (this.manufacturers == null)
                {
                    this.manufacturers = new ObservableCollection<Manufacturer>();
                }

                this.manufacturers.Clear();
                foreach (var item in value)
                {
                    this.manufacturers.Add(item);
                }
            }
        }
    }
}
