namespace MobileCarMarket.ViewModels
{
    using System;
    using System.Windows.Input;
    using System.IO;
    using Windows.Storage;
    using System.Net.Http;

    using Helpers;
    using Http;
    using LocalDb;
    using LocalDb.Models;
    
    public class StartUpContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand signInCommand;
        private ICommand singUpCommand;
        private bool isSigningIn = false;

        public ICommand SignInCommand
        {
            get
            {
                if (this.signInCommand == null)
                {
                    this.signInCommand = new DelegateCommandWithParameter<StartUpViewModel>(async (model) =>
                    {
                        if(this.isSigningIn == true)
                        {
                            return;
                        }

                        if(model.Email.Length == 0)
                        {
                            Notification.Publish("Please input email");
                            return;
                        }

                        if (model.Password.Length == 0)
                        {
                            Notification.Publish("Please input password");
                            return;
                        }

                        this.isSigningIn = true;

                        var httpAuth = new HttpAuth("http://localhost:60178/token");

                        HttpResult authResult = null;

                        try
                        {
                            authResult = await httpAuth.Login(model.Email, model.Password);
                        }
                        catch(HttpRequestException)
                        {
                            this.isSigningIn = false;
                            Notification.Publish("Server seems down");
                            return;
                        }

                        if(authResult.Succeeded == false)
                        {
                            this.isSigningIn = false;
                            Notification.Publish("Wrong username or password");
                            return;
                        }

                        var userDbFile = Path.Combine(ApplicationData.Current.LocalFolder.Path, model.Email + ".db3");
                        var userDbKeySeed = CryptoUtils.GenerateHash(model.Email, model.Password);
                        LocalStorage.Initialize(userDbFile, userDbKeySeed);

                        var storage = LocalStorage.GetInstance;
                        var token = new Token()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Data = authResult.Result
                        };

                        storage.SecureInsert<Token>(token, LocalStorage.KeySeed);

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
