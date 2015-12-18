namespace MobileCarMarket.ViewModels
{
    using System.Windows.Input;

    using Helpers;
    using Http;

    public class StartUpContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand signInCommand;
        private ICommand singUpCommand;

        public ICommand SignInCommand
        {
            get
            {
                if (this.signInCommand == null)
                {
                    this.signInCommand = new DelegateCommandWithParameter<StartUpViewModel>(async (model) =>
                    {
                        if(model.Email.Length == 0)
                        {
                            MessageBox.Show("Blank email");
                            return;
                        }

                        if (model.Password.Length == 0)
                        {
                            MessageBox.Show("Blank password");
                            return;
                        }

                        var httpAuth = new HttpAuth("http://localhost:60178/token");
                        var authResult = await httpAuth.Login(model.Email, model.Password);

                        if(authResult.Succeeded == false)
                        {
                            MessageBox.Show("Wrong username or password");
                            return;
                        }

                        new NavigationService().Navigate(typeof(NavigationPage));
                    });
                }

                return this.signInCommand;
            }
        }

        public ICommand SignUpCommand
        {
            get
            {
                if (this.singUpCommand == null)
                {
                    this.singUpCommand = new DelegateCommand(() =>
                    {
                        new NavigationService().Navigate(typeof(RegistrationPage));
                    });
                }

                return this.singUpCommand;
            }
        }
    }
}
