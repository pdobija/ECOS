using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ECOS.Models
{
    public class Subject
    {
        public Subject()
        {
            SubjectSemesters = new List<SubjectSemester>();
        }
        [Key]
        public string Subject_code { set; get; }
        public string Subject_name { set; get; }

        public virtual ICollection<SubjectSemester> SubjectSemesters { set; get; }
    }
}
