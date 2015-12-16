using MobileCarMarket.Helpers;
using System.Windows.Input;

namespace MobileCarMarket.ViewModels
{
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
                    this.signInCommand = new DelegateCommandWithParameter<StartUpViewModel>((model) =>
                    {

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

                    });
                }

                return this.singUpCommand;
            }
        }
    }
}
