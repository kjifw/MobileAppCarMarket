namespace MobileCarMarket.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public RegistrationViewModel()
            : this(string.Empty, string.Empty, string.Empty)
        {
        }

        public RegistrationViewModel(RegistrationViewModel model)
            : this(model.Username, model.Password, model.ConfirmPassword)
        {
        }

        public RegistrationViewModel(string username, string password, string confirmPassword)
        {
            this.Username = username;
            this.Password = password;
            this.ConfirmPassword = confirmPassword;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
