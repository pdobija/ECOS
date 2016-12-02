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
        [Key]
        public int Album_number { set; get; }
        public string First_name { set; get; }
        public string Last_name { set; get; }

        public  Login Login { set; get; }
        public virtual Student_on_semester Student_on_semester { set; get; }
    }
}
