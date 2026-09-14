using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;


namespace V3_Dag4_Ovn1_Intro.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Func<Task> _execute;
        public RelayCommand(Func<Task> execute)
        {
            _execute = execute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            await _execute();
        }
    }

}