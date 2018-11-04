using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Web.Models;

[assembly: OwinStartupAttribute(typeof(Web.Startup))]
namespace Web
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();


           // OwinInit(app);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

        }

        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admin"))
            {
                role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Ressource"))
            {
                role = new IdentityRole();
                role.Name = "Ressource";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Client"))
            {
                role = new IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Manager"))
            {
                role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }
        }
    }
}
