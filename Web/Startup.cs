using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
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
            CreateUsers();
        }
        public void CreateUsers ()
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "admin@admin.com";
            //user.UserName = user.Email;
                  
            var check = UserManager.Create(user,"123@Dmin");  
            if (check.Succeeded) {
                UserManager.AddToRole(user.Id, "Admin");
            }

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
