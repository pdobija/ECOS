using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECOS.Command
{
    public class CloseWindowCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return (parameter is System.Windows.Window);
        }

        public void Execute(object parameter)
        {
            System.Windows.Window window = parameter as System.Windows.Window;
            if(window == null)
            {
                return;
            }
            window.Close();
        }
    }
}
