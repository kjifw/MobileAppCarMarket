namespace MobileCarMarket.ViewModels
{
    public class StartUpViewModel : ViewModelBase
    {
        public StartUpViewModel()
            : this(string.Empty, string.Empty)
        {
        }

        public StartUpViewModel(StartUpViewModel model)
            : this(model.Email, model.Password)
        {
        }

        public StartUpViewModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
