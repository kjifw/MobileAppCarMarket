namespace MobileCarMarket.ViewModels
{
    public class StartUpViewModel : ViewModelBase
    {
        public StartUpViewModel()
            : this(string.Empty, string.Empty)
        {
        }

        public StartUpViewModel(StartUpViewModel model)
            : this(model.Username, model.Password)
        {
        }

        public StartUpViewModel(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
