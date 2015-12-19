namespace MobileCarMarket.ViewModels
{
    using System.Windows.Input;
    using System.IO;
    using Windows.Storage;

    using Helpers;
    using Http;
    using LocalDb;

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

                        var userDbFile = Path.Combine(ApplicationData.Current.LocalFolder.Path, model.Email + ".db3");
                        var userDbKeySeed = CryptoUtils.GenerateHash(model.Email, model.Password);
                        LocalStorage.Initialize(userDbFile, userDbKeySeed);

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
