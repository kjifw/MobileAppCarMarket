namespace MobileCarMarket.ViewModels
{
    using System.Windows.Input;
    using System.Net.Http;

    using Helpers;
    using Http;
    
    public class RegistrationContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand signUpCommand;
        private bool isSigningUp = false;

        public ICommand SignUpCommand
        {
            get
            {
                if (this.signUpCommand == null)
                {
                    this.signUpCommand = new DelegateCommandWithParameter<RegistrationViewModel>(async (model) =>
                    {
                        if(this.isSigningUp == true)
                        {
                            return;
                        }

                        if(model.Email.Length == 0)
                        {
                            Notification.Publish("Please input email");
                            return;
                        }

                        if(model.Password.Length == 0)
                        {
                            Notification.Publish("Please input password");
                            return;
                        }

                        if(model.ConfirmPassword.Length == 0)
                        {
                            Notification.Publish("Please confirm password");
                            return;
                        }

                        if(model.Password != model.ConfirmPassword)
                        {
                            Notification.Publish("Password and confirm password does not match");
                            return;
                        }

                        this.isSigningUp = true;

                        var httpAuth = new HttpAuth("http://localhost:60178/api/account/register");

                        HttpResult authResult = null;

                        try
                        {
                            authResult = await httpAuth.Register(model.Email, model.Password, model.ConfirmPassword);
                        }
                        catch(HttpRequestException)
                        {
                            this.isSigningUp = false;
                            Notification.Publish("Server seems down");
                            return;
                        }
                        
                        if(authResult.Succeeded == false)
                        {
                            this.isSigningUp = false;
                            Notification.Publish("Error. Email is probably already registered");
                            return;
                        }

                        this.isSigningUp = false;
                        Notification.Publish("Account successfully registered");
                        new NavigationService().Navigate(typeof(MainPage));
                    });
                }

                return this.signUpCommand;
            }
        }
    }
}
