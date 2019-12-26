using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using E_ticaret.MvcWebUi.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace E_ticaret.MvcWebUi.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name="admin",Description="yonetici rolü"};
                manager.Create(role);

            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name="user",Description="user rolü"};
                manager.Create(role);

            }

            if (!context.Users.Any(i => i.Name == "mmuhammedgcr"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "muhammed", LastName="gocer", UserName="mmuhammedgcr",Email="mmuhammedgcr@gmail.com"};

                manager.Create(user,"123456");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");

            }
            if (!context.Users.Any(i => i.Name == "osmangcr"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "osman", LastName = "gocer", UserName = "osmangcr", Email = "osmangcr@gmail.com" };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user");

            }




            base.Seed(context);
        }
    }
}