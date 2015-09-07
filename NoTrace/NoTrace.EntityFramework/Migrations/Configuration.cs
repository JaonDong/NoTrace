using NoTrace.Core.MultiTenancy;
using NoTrace.Core.Users;

namespace NoTrace.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NoTrace.EntityFramework.EntityFramework.NoTraceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NoTrace.EntityFramework.EntityFramework.NoTraceDbContext context)
        {
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
            //if (!context.Tenants.Any())
            //{
            //    context.Tenants.Add(new Tenant("tenancyName", "name"));
            //    context.SaveChanges();
            //}

            //if (!context.Users.Any())
            //{
            //    context.Users.Add(new User()
            //    {
            //        UserName = "username",
            //        Name = "name",
            //        Tenant = context.Tenants.First()
            //    });
            //    context.SaveChanges();
            //}
        
        }
    }
}
