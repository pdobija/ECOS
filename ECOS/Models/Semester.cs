using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECOS.Models
{
    public class Semester
    {
        public Semester()
        {
            Students = new List<Student>();
            SubjectSemesters = new List<SubjectSemester>();
        }
        [Key]
        public int Semester_ID { set; get; }
        public string Course { set; get; }
        public int Year { set; get; }
        public int Semester_number { set; get; }
        public virtual ICollection<Student> Students { set; get; }
        public virtual ICollection<SubjectSemester> SubjectSemesters { set; get; }
    }
}
