using ECOS.Command;
using ECOS.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOS.ViewModel
{
    public class StudentDetailsViewModel:ViewModelBase
    {
        private Student _currentStudent;
        private CloseWindowCommand _closeCommand;
        
        public Student CurrentStudent
        {
            get { return _currentStudent; }
            set
            {
                if (value == _currentStudent) return;
                _currentStudent = value;
                RaisePropertyChanged(() => CurrentStudent);
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
        public StudentDetailsViewModel()
        {
            _currentStudent = new Student();
            _closeCommand = new CloseWindowCommand();
        }

        public StudentDetailsViewModel(Student student) : this()
        {
            _currentStudent = student;
        }
    }
}
