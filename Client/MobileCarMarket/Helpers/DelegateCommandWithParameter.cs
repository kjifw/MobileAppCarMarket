namespace MobileCarMarket.Helpers
{
    using System;
    using System.Windows.Input;

    public class DelegateCommandWithParameter<T> : ICommand
    {
        private Action<T> execute;

        public DelegateCommandWithParameter(Action<T> execute)
        {
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.execute((T)parameter);
        }
    }
}
