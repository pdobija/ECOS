namespace ECOS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECOS.ECOS_Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; ;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ECOS.ECOS_Context context)
        {


            context.Worker.AddOrUpdate(new Models.Worker() { Worker_ID = 1, First_name = "Piotr", Last_name = "Dobija" });
            context.Logins.AddOrUpdate(new Models.Login() { Worker_ID = 1, User_name = "admin", Password = "21232f297a57a5a743894a0e4a801fc3", Role = "ADM"});
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
