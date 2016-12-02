using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ECOS.Models
{
    public class Worker
    {
        [Key]
        public int Worker_ID { set; get; }
        public string First_name { set; get; }
        public string Last_name { set; get; }
        public string Degree { set; get; }

        public virtual Login Login { set; get; }
    }
}
