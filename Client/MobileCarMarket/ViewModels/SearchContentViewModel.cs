﻿namespace MobileCarMarket.ViewModels
{
    using Helpers;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class SearchContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand searchCommand;
        private ObservableCollection<Manufacturer> manufacturers;

        public ICommand SearchCommand
        {
            get
            {
                if (this.searchCommand == null)
                {
                    this.searchCommand = new DelegateCommandWithParameter<SearchViewModel>((model) =>
                    {

                    });
                }

                return this.searchCommand;
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