using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOS.Models
{
    public class Login
    {    
        [Key]
        public string User_name { get; set; }
        public string Password { set; get; }
        public string Role { set; get; }
        public bool IsEnable { set; get; }
        public int? Album_number { set; get; }
        public int? Worker_ID { set; get; }

        [ForeignKey("Album_number")]
        public virtual Student Students { set; get; }
        [ForeignKey("Worker_ID")]
        public virtual Worker Workers { set; get; }
    }
}
