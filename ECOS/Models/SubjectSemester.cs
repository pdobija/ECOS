using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOS.Models
{
    public class SubjectSemester
    {
        public SubjectSemester()
        {
            Sections = new List<Section>();
        }
           
        [Key]
        [Column(Order = 0)]
        public int Semester_ID { set; get; }
       [Key]
       [Column(Order = 1)]
        public string Subject_code { set; get; }
        public int Worker_ID { set; get; }

        [ForeignKey("Subject_code")]
        public virtual Subject Subject { set; get; }
        [ForeignKey("Semester_ID")]
        public virtual Semester Semester { set; get; }
        [ForeignKey("Worker_ID")]
        public virtual Worker Worker { set; get; }

        public virtual ICollection<Section> Sections { set; get; }

    }
}
