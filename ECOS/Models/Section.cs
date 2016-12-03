using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOS.Models
{
    public class Section
    {
        public Section()
        {
            StudentSections = new List<StudentSection>();
        }
        [Key]
        public int Section_ID { set; get; }
        public string Description { set; get; }
        public int Worker_ID { set; get; }
        public int Semester_ID { set; get; }
        public string Subject_code { set; get; }

        [ForeignKey("Worker_ID")]
        public virtual Worker Worker { set; get; }
        public virtual SubjectSemester SubjectSemester { set; get; }
        public virtual ICollection<StudentSection> StudentSections { set; get; }
    }
}
