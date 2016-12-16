using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOS.Enums;
using ECOS.Broker;

namespace ECOS.ViewModel
{
    public class EditItemViewModel
    {

        public EditItemViewModel()
        {
            OpenWorkerDesignerCommand = new RelayCommand(() =>WorkerDesigner_Method());
            OpenStudentDesignerCommand = new RelayCommand(() => StudentDesigner_Method());
        }

        public RelayCommand OpenWorkerDesignerCommand { get; private set; }

        public RelayCommand OpenStudentDesignerCommand { get; private set; }

        private void StudentDesigner_Method()
        {
            GUI_broker.openStudentDesigner();

        }
        private void WorkerDesigner_Method()
        {
            GUI_broker.openWorkerDesigner();
        }
    }
}
