using GalaSoft.MvvmLight;
using ECOS.Models;
using GalaSoft.MvvmLight.Command;
using ECOS.Enums;
using ECOS.DataAccesLayer;
using ECOS.Broker;

namespace ECOS.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private Login _login;
        private log_status _log_status;
        public RelayCommand LogIn_Command { private set; get; }

        public LoginViewModel()
        {
            Login = new Login();
            LogIn_Command = new RelayCommand(() => LogIn_method());
        }
      
        public Login Login
        {
            get {

                return _login;
            }
            set
            {
                if (value == _login)
                    return;
                _login = value;
                RaisePropertyChanged(() => Login);
            }
        }
        public string User_name
        {
            get {
                return Login.User_name;
            }
            set
            {
                if (value == Login.User_name)
                    return;
                Login.User_name = value;
                RaisePropertyChanged(() => Login.User_name);
            }
        }
        public string Password
        {
            get { return Login.Password; }
            set
            {
                if (value == Login.Password)
                    return;
                Login.Password = value;
                RaisePropertyChanged(() => Login.Password);
            }
        }
  

        private void LogIn_method()
        {

            string role = Db_manager.check_login(User_name, Password, ref _log_status);
            GUI_broker.Show_login_status(role, _log_status);
           
           
        }


    }
}
