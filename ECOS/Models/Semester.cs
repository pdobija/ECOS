using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOS.Models
{
    public class Semester
    {
        [Key]
        public int Semester_ID { set; get; }
        public string Course { set; get; }
        public int Year { set; get; }
        public int Semester_number { set; get; }

        public virtual Student_on_semester Student_on_semester { set; get; }
    }
}
