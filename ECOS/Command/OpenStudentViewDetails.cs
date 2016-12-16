using ECOS.Models;
using ECOS.View;
using ECOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECOS.Command
{
    public class OpenStudentViewDetails : ICommand
    {
        public Action<Student> AfterExecuted { get; set; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Student student = parameter as Student;

            StudentDetailsViewModel viewModel = student != null
                ? new StudentDetailsViewModel(student)
                : new StudentDetailsViewModel();
            StudentDetailsView editView = new StudentDetailsView
            {
                DataContext = viewModel
            };
            editView.ShowDialog();

            if (AfterExecuted != null)
                AfterExecuted.Invoke(viewModel.CurrentStudent);
        }
    }
}
