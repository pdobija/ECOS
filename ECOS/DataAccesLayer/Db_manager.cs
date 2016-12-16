using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOS.Enums;
using System.Security.Cryptography;
using System.Collections.ObjectModel;
using ECOS.Models;
using ECOS.Broker;

namespace ECOS.DataAccesLayer
{
   public static class Db_manager
    {
        public static void add_worker(Worker worker)
        {
            using (ECOS_Context database = new ECOS_Context())
            {
                Worker editWorker = new Worker();
                editWorker = database.Worker.FirstOrDefault(w => w.Worker_ID == worker.Worker_ID);
                if (editWorker == null)
                {
                    string user_name = null;
                    string password = null;
                    AccountGenerator.generate_account(ref user_name, ref password, worker, "WORK");
                    worker.Logins.Add(new Login { User_name = user_name, Password = password, IsEnable = true, Role = "WORK" });
                    database.Worker.Add(worker);
                }
                else
                {
                    editWorker.First_name = worker.First_name;
                    editWorker.Last_name = worker.Last_name;
                    editWorker.Degree = worker.Degree;
                    database.Entry(editWorker).State = System.Data.Entity.EntityState.Modified;
                }
                database.SaveChanges();
            }
        }

        public static void add_student(Student student)
        {
            using (ECOS_Context database = new ECOS_Context())
            {
                Student editWorker = new Student();
                editWorker = database.Students.FirstOrDefault(s => s.Album_number == student.Album_number);
                if (editWorker == null)
                {
                    string user_name = null;
                    string password = null;
                    AccountGenerator.generate_account(ref user_name, ref password, student, "STUD");
                    student.Logins.Add(new Login { User_name = user_name, Password = password, IsEnable = true, Role = "STUD" });
                    database.Students.Add(student);
                }
                else
                {
                    editWorker.First_name = student.First_name;
                    editWorker.Last_name = student.Last_name;
                    editWorker.Album_number = student.Album_number;
                    database.Entry(editWorker).State = System.Data.Entity.EntityState.Modified;
                }
                database.SaveChanges();
            }
        }
        public static ObservableCollection<Student> get_student_collection(string first_name, string last_name)
        {
            first_name = first_name == null ? "" : first_name;
            last_name = last_name == null ? "" : last_name;
            ObservableCollection<Student> stud = new ObservableCollection<Student>();
            using (ECOS_Context database = new ECOS_Context())
            {
                var students = database.Students.Where(s => (s.First_name.StartsWith(first_name) && s.Last_name.StartsWith(last_name)));

                foreach (var student in students)
                {
                    stud.Add(student);
                }

            }
            return stud;
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
                else if (user.IsEnable == false)
                {
                    log_status = log_status.disable;
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
