using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
