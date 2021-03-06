﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ECOS.Models
{
    public class Worker
    {
        public Worker()
        {
            Logins = new List<Login>();
            SubjectSemesters = new List<SubjectSemester>();
            Sections = new List<Section>();
        }
        [Key]
        public int Worker_ID { set; get; }
        public string First_name { set; get; }
        public string Last_name { set; get; }
        public string Degree { set; get; }

        public virtual ICollection<Section> Sections { set; get; }
        public virtual ICollection<Login> Logins { set; get; }
        public virtual ICollection<SubjectSemester> SubjectSemesters { set; get; }
    }
}
