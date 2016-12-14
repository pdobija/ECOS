using ECOS.Enums;
using System.Windows;
using ECOS.View;

namespace ECOS.Broker
{
    public static class GUI_broker
    {

        public static void show_creating_worker_status(bool status)
        {
            if(status)
            {
                MessageBox.Show("New worker has been added to the database", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Not all fields have been correctly completed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


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
                case log_status.out_of_date:
                    MessageBox.Show("Validity of account has expired", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case log_status.correct:

                    switch (role)
                    {
                        case "ADM":
                            AdminView AdminView = new AdminView();
                            Application.Current.MainWindow = AdminView;
                            AdminView.ShowDialog();
                   
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
