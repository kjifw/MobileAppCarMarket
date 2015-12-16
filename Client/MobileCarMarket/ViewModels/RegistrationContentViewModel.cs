using MobileCarMarket.Helpers;
using System.Windows.Input;

namespace MobileCarMarket.ViewModels
{
    public class RegistrationContentViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand signUpCommand;

        public ICommand SignUpCommand
        {
            get
            {
                if (this.signUpCommand == null)
                {
                    this.signUpCommand = new DelegateCommandWithParameter<RegistrationViewModel>((model) =>
                    {

                    });
                }

                return this.signUpCommand;
            }
        }
    }
}
