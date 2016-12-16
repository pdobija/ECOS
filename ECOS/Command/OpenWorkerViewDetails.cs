using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOS.Models;
using System.Windows.Input;
using ECOS.ViewModel;
using ECOS.View;

namespace ECOS.Command
{
     public class OpenWorkerViewDetails : ICommand
    {
        public Action<Worker> AfterExecuted { get; set; }
        public event EventHandler CanExecuteChanged;



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Worker worker = parameter as Worker;
            WorkerDetailsViewModel viewModel = worker != null
                                                    ? new WorkerDetailsViewModel(worker)
                                                    : new WorkerDetailsViewModel();
            WorkerViewDetails editView = new WorkerViewDetails
            {
                DataContext = viewModel
            };

            editView.ShowDialog();
            if (AfterExecuted != null)
            {
                AfterExecuted.Invoke(viewModel.CurrentWorker);
            }
        }
    }
}
