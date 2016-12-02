using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public DateTime? Account_date { set; get; }
        public int Worker_ID { set; get; }
        public int Album_number { set; get; }

        [ForeignKey("Album_number")]
        public virtual Student Student { set; get; }

        [ForeignKey("Worker_ID")]
        public virtual Worker Worker { set; get; }



    }
}
