using ECOS.Models;
using System.Data.Entity;

namespace ECOS
{
    public class ECOS_Context : DbContext
    {
        public ECOS_Context():base()
        {
            Database.SetInitializer<ECOS_Context>(new MigrateDatabaseToLatestVersion<ECOS_Context,ECOS.Migrations.Configuration>());
        }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Semester> Semester { set; get; }
        public DbSet<Subject> Subject { set; get; }
        public DbSet<Section>  Section {set;get;}
        public DbSet<SubjectSemester> SubjectSemester { get; set; }
        public DbSet<StudentSection> StudentSection { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
