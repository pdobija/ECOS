using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOS.Models
{
    public class Student
    {
        public Student()
        {
            Logins = new List<Login>();
            Semesters = new List<Semester>();
        }
        [Key]
        public int Album_number { set; get; }
        public string First_name { set; get; }
        public string Last_name { set; get; }


        public virtual ICollection<Login> Logins { set; get; }
        public virtual ICollection<Semester> Semesters { set; get; }
    }
}
