using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOS.Command;
using ECOS.Models;
using GalaSoft.MvvmLight;

namespace ECOS.ViewModel
{
    public class WorkerDetailsViewModel :ViewModelBase
    {


        private Worker _currentWorker;
        private CloseWindowCommand _closeCommand;

        public Worker CurrentWorker
        {
            get { return _currentWorker; }
            set
            {
                if (value == _currentWorker) return;
                _currentWorker = value;
                RaisePropertyChanged(() => CurrentWorker);
            }
        }

        public CloseWindowCommand CloseWindowCommand
        {
            get { return _closeCommand; }
            set
            {
                if (value == _closeCommand) return;
                _closeCommand = value;
                RaisePropertyChanged(() => CloseWindowCommand);
            }
        }
        public WorkerDetailsViewModel()
        {
            _currentWorker = new Worker();
            _closeCommand = new CloseWindowCommand();
        }

        public WorkerDetailsViewModel(Worker worker) :this()
        {
            _currentWorker = worker;
        }
    }
}
