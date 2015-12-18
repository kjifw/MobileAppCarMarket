namespace MobileCarMarket.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public RegistrationViewModel()
            : this(string.Empty, string.Empty, string.Empty)
        {
        }

        public RegistrationViewModel(RegistrationViewModel model)
            : this(model.Email, model.Password, model.ConfirmPassword)
        {
        }

        public RegistrationViewModel(string email, string password, string confirmPassword)
        {
            this.Email = email;
            this.Password = password;
            this.ConfirmPassword = confirmPassword;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
