﻿namespace MobileCarMarket.ViewModels
{
    using System.Windows.Input;

    using Helpers;
    using Http;

    public class RegistrationContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand signUpCommand;

        public ICommand SignUpCommand
        {
            get
            {
                if (this.signUpCommand == null)
                {
                    this.signUpCommand = new DelegateCommandWithParameter<RegistrationViewModel>(async (model) =>
                    {
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

                        var httpAuth = new HttpAuth("http://localhost:60178/api/account/register");
                        var authResult = await httpAuth.Register(model.Email, model.Password, model.ConfirmPassword);
                        
                        if(authResult.Succeeded == false)
                        {
                            Notification.Publish("Error. Email is probably already registered");
                            return;
                        }

                        Notification.Publish("Account successfully registered");
                        new NavigationService().Navigate(typeof(MainPage));
                    });
                }

                return this.signUpCommand;
            }
        }
    }
}
