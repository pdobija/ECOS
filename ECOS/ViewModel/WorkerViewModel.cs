using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ECOS.Models;
using System.Collections.ObjectModel;
using ECOS.DataAccesLayer;
using ECOS.Command;
using System.Windows;
using ECOS.Broker;

namespace ECOS.ViewModel
{

    public class WorkerViewModel : ViewModelBase
    {
        private OpenWorkerViewDetails _workerDetailsCommand;

        public OpenWorkerViewDetails WorkerDetailsCommand
        {
            get { return _workerDetailsCommand; }
            set
            {
                if (value == _workerDetailsCommand)
                    return;
                _workerDetailsCommand = value;
                RaisePropertyChanged(() => WorkerDetailsCommand);
            }
        }

        private ObservableCollection<Worker> _workers;
        public RelayCommand GetWorkerCommand { private set; get; }
        public RelayCommand Logout { private set; get; }
        private void LogOut_method()
        {
            Application.Current.MainWindow.Close();
        }
        public ObservableCollection<Worker> workers
        {
            get { return _workers; }
            set
            {
                if (value == _workers)
                    return;
                _workers = value;
                RaisePropertyChanged(() => workers);
            }
        }

        private Worker _worker;
 
        public WorkerViewModel()
        {
            worker = new Worker();
            workers = new ObservableCollection<Worker>();
            GetWorkerCommand = new RelayCommand(() => Get_worker_collection());
            Logout = new RelayCommand(() => LogOut_method());
            WorkerDetailsCommand = new OpenWorkerViewDetails();
            WorkerDetailsCommand.AfterExecuted += work =>
            {
                if (!(Booker.Tester.test_worker(work)))
                {
                    GUI_broker.show_creating_worker_status(true);
                    return;

                }
                else if (!workers.Contains(work))
                 {
                    workers.Add(work);
                    
                }
                
                Db_manager.add_worker(work);     
                GUI_broker.show_creating_worker_status(false);    
            };
        }
  
        public Worker worker
        {
            get { return _worker; }
            set
            {
                if (value == _worker)
                    return;
                _worker = value;
                RaisePropertyChanged(() => worker);
            }
        }
            

        public int Worker_ID
        {
            get { return worker.Worker_ID; }
            set
            {
                if (value == worker.Worker_ID)
                    return;
                worker.Worker_ID = value;
                RaisePropertyChanged(() => worker.Worker_ID);
            }
        }
        public string First_name
        {
            get { return worker.First_name; }
            set
            {
                if (value == worker.First_name)
                    return;
                worker.First_name = value;
                RaisePropertyChanged(() => worker.First_name);
            }
        }
        public string Last_name
        {
            get { return worker.Last_name; }
            set
            {
                if (value == worker.Last_name)
                    return;
                worker.Last_name = value;
                RaisePropertyChanged(() => worker.Last_name);
            }
        }
        public string Degree
        {
            get { return worker.Degree; }
            set
            {
                if (value == worker.Degree)
                    return;
                worker.Degree = value;
                RaisePropertyChanged(() => worker.Degree);
            }
        }

        private void Get_worker_collection()
        {
           workers =  Db_manager.get_worker_collection(First_name, Last_name);
        }
    }
}
