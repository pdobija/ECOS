using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOS.Models
{
    public class Student_on_semester
    {
        [Key]
        public int Album_number { set; get; }
        [Key]
        public int Semester_ID { set; get; }
        [ForeignKey("Album_number")]
        public virtual ICollection<Student> Students { set; get; }
        [ForeignKey("Semester_ID")]
        public virtual ICollection<Semester> Semesters { set; get; }

    }

}
