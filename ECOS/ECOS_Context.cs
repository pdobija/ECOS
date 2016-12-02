using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ECOS.Models;

namespace ECOS
{
    public class ECOS_Context:DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Semester> Semester { set; get; }
        public DbSet<Student_on_semester> Student_on_semesters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
