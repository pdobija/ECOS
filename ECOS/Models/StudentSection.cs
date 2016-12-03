using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOS.Models
{
    public class StudentSection
    {
        [Key]
        [Column(Order = 0)]
        public int Section_ID { set; get; }
        [Key]
        [Column(Order = 1)]
        public int Album_number { set; get; }

        public int Mark { set; get; }
        public DateTime Mark_date { set; get; }

        [ForeignKey("Album_number")]
        public virtual Student Student { set; get; }
        [ForeignKey("Section_ID")]
        public virtual Section Section { set; get; }

    }
}
