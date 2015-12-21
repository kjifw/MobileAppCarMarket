namespace MobileCarMarket.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using Helpers;
    using RemoteServiceModels;
    using Http;
    using LocalDb;
    using LocalDb.Models;

    public class SearchContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand searchCommand;
        private ObservableCollection<Manufacturer> manufacturers;
        private ObservableCollection<SearchResult> searchResults;

        public ICommand SearchCommand
        {
            get
            {
                if (this.searchCommand == null)
                {
                    this.searchCommand = new DelegateCommandWithParameter<SearchViewModel>(async (model) =>
                    {
                        if(model.Manufacturer == null)
                        {
                            Notification.Publish("Please select manufacturer");
                            return;
                        }

                        if(model.Model == null)
                        {
                            Notification.Publish("Please select model");
                            return;
                        }

                        this.SearchResults = await SearchAdverts(model);
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

        public IEnumerable<SearchResult> SearchResults
        {
            get
            {
                if (this.searchResults == null)
                {
                    this.searchResults = new ObservableCollection<SearchResult>();
                }

                return this.searchResults;
            }
            set
            {
                if (this.searchResults == null)
                {
                    this.searchResults = new ObservableCollection<SearchResult>();
                }

                this.searchResults.Clear();
                foreach (var item in value)
                {
                    this.searchResults.Add(item);
                }
            }
        }

        public async Task<ICollection<SearchResult>> SearchAdverts(SearchViewModel model)
        {
            var searchResults = new ObservableCollection<SearchResult>();

            var searchFilters = new SearchAdvertsFiltersModel()
            {
                Make = model.Manufacturer.Name,
                Model = model.Model,
                IsNew = model.IsNew
            };

            var serializedSearchFilters = JsonConvert.SerializeObject(searchFilters);

            var searchAdvertsApiUrl = "http://localhost:60178/api/adverts/search";
            var storage = LocalStorage.GetInstance;
            var token = storage.SecureGetAll<Token>(LocalStorage.KeySeed)[storage.SecureGetCount<Token>() - 1];

            var httpDataDownloader = new HttpDataDownloader(searchAdvertsApiUrl, token.Data);
            var result = await httpDataDownloader.DownloadJsonData(serializedSearchFilters);

            if(result.Succeeded == true)
            {
                var matches = JsonConvert.DeserializeObject<List<SearchResult>>(result.Result);

                foreach(var match in matches)
                {
                    searchResults.Add(new SearchResult(match.Manufacturer, match.Model, match.Price, match.ImageUrl));
                }
            }

            return searchResults;
        }
    }
}
