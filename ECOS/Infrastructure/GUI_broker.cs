using ECOS.Enums;
using System.Windows;
using ECOS.View;
using System;

namespace ECOS.Broker
{
    public static class GUI_broker
    {

        public static void openWorkerDesigner()
        {
            AdminView WVD = new AdminView();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = WVD;

            WVD.ShowDialog();
        }
        public static void openStudentDesigner()
        {
            StudentDesignView WVD = new StudentDesignView();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = WVD;

            WVD.ShowDialog();
        }
        public static void show_creating_student_status(bool status)
        {
            if (status == true)
                MessageBox.Show("The student was not added to the database because:\n\n- Not all the data has been completed\n- Access to the database is locked", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (status == false)
                MessageBox.Show("Student has been updated/added to the database", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


        }

        internal static void openSemesterDesigner()
        {
            SemesterDesignerView WVD = new SemesterDesignerView();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = WVD;

            WVD.ShowDialog();
        }

        public static void show_creating_worker_status(bool? status)
        {
            if (status == true)
                MessageBox.Show("The worker was not added to the database because:\n\n- Not all the data has been completed\n- Access to the database is locked", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (status == false)
                MessageBox.Show("Worker has been updated/added to the database", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
 

        }
        public static void Show_login_status(string role, log_status status)
        {
            switch (status)
            {
                case log_status.wrong_user:
                    MessageBox.Show("The given user name does not exist", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

                case log_status.wrong_pass:
                    MessageBox.Show("The specified password is incorrect", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case log_status.disable:
                    MessageBox.Show("Acces to your account was disable", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case log_status.correct:

                    switch (role)
                    {
                        case "ADM":
                            ChooseEditItemView EditView = new ChooseEditItemView();
                            Application.Current.MainWindow = EditView;
                            EditView.ShowDialog();
                   
                            break;
                    }
                    //    case "PRAC":
                    //        this.Visible = false;
                    //        WorkerForm WorkerForm = new WorkerForm((int)user.WORKER_ID);
                    //        WorkerForm.ShowDialog();
                    //        this.Close();
                    //        break;
                    //    case "STUD":
                    //        this.Visible = false;
                    //        StudentForm StudentForm = new StudentForm((int)user.ALBUM_NUMBER);
                    //        StudentForm.ShowDialog();
                    //        this.Close();
                    //        break;
                    //    default:

                    break;
            }
        }
    }
}
