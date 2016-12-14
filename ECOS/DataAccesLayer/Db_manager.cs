using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOS.Enums;
using System.Security.Cryptography;
using System.Collections.ObjectModel;
using ECOS.Models;

namespace ECOS.DataAccesLayer
{
   public static class Db_manager
    {
        public static void add_worker(Worker worker)
        {
            using (ECOS_Context database = new ECOS_Context())
            {
                database.Worker.Add(worker);
                database.SaveChanges();
            }
            }
        public static ObservableCollection<Worker> get_worker_collection(string first_name,string last_name)
        {
            first_name = first_name == null ? "" : first_name;
            last_name = last_name == null ? "" : last_name;
            ObservableCollection<Worker> work = new ObservableCollection<Worker>();
            using (ECOS_Context database = new ECOS_Context())
            {
                var workers = database.Worker.Where(s=>(s.First_name.StartsWith(first_name) && s.Last_name.StartsWith(last_name)));

                foreach (var wor in workers)
                {
                    work.Add(wor);
                }

            }
            return work;
        }
        public static string check_login(string user_name, string password, ref log_status log_status)
        {
            using (ECOS_Context database = new ECOS_Context())
            {
                password = password == null ? "" : password;
                var user = database.Logins.SingleOrDefault(u=>(u.User_name == user_name));
                if (user == null)
                {
                    log_status = log_status.wrong_user;
                    return null;
                }
                else if (MD5Hash(password) != user.Password)
                {
                    log_status = log_status.wrong_pass;
                    return null;
                }
                else if ((user.Account_date <= DateTime.Now && user.Account_date != null))
                {
                    log_status = log_status.out_of_date;
                    return null;
                }
                log_status = log_status.correct;
                return user.Role;
            }
        }

        private static string MD5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();

        }
    }
}
