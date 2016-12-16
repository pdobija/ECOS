using ECOS.Command;
using ECOS.DataAccesLayer;
using ECOS.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ECOS.Broker;

namespace ECOS.ViewModel
{
   public class StudentViewModel:ViewModelBase
    {
        private OpenStudentViewDetails _studentDetailsCommand;

        public OpenStudentViewDetails StudentDetailsCommand
        {
            get { return _studentDetailsCommand; }
            set
            {
                if (value == _studentDetailsCommand)
                    return;
                _studentDetailsCommand = value;
                RaisePropertyChanged(() => StudentDetailsCommand);
            }
        }


        private void Get_student_collection()
        {
            students = Db_manager.get_student_collection(First_name, Last_name);
        }

        private ObservableCollection<Student> _students;
        public RelayCommand GetStudentsCommand{private set; get; }
        public RelayCommand Logout { private set; get; }
        private void LogOut_method()
        {
            Application.Current.MainWindow.Close();
        }
        public ObservableCollection<Student> students
        {
            get { return _students; }
            set
            {
                if (value == _students)
                    return;
                _students = value;
                RaisePropertyChanged(() => students);
            }
        }

        public StudentViewModel()
        {
            students = new ObservableCollection<Student>();
            student = new Student();
            GetStudentsCommand = new RelayCommand(() => Get_student_collection());
            Logout = new RelayCommand(() => LogOut_method());
            StudentDetailsCommand = new OpenStudentViewDetails();
            StudentDetailsCommand.AfterExecuted += stud =>
            {
                if (!(Booker.Tester.test_student(stud)))
                {
                    GUI_broker.show_creating_student_status(true);
                    return;
                }
                else if (!students.Contains(stud))
                    students.Add(stud);
                Db_manager.add_student(stud);
                GUI_broker.show_creating_student_status(false);
            };
        }
        private Student _student;

        public Student student
        {
            get { return _student; }
            set
            {
                if (value == _student) return;
                _student = value;
                RaisePropertyChanged(() => student);
            }
        }
        public int Album_number
        {
            get { return student.Album_number; }
            set
            {
                if (value == student.Album_number) return;
                student.Album_number = value;
                RaisePropertyChanged(() => Album_number);
            }
        }
        public string First_name
        {
            get { return student.First_name; }
            set
            {
                if (value == student.First_name)
                    return;
                student.First_name = value;
                RaisePropertyChanged(() => student.First_name);
            }
        }
        public string Last_name
        {
            get { return student.Last_name; }
            set
            {
                if (value == student.Last_name)
                    return;
                student.Last_name = value;
                RaisePropertyChanged(() => student.Last_name);
            }
        }

    }
}
