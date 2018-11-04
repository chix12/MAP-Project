using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class User : IdentityUser <int, Login, UserRole, Claim>
    {
        [Key]
        public int UserId { get; set;}
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }
    public class Claim : IdentityUserClaim<int>
    {
        [Key]
        public int idClaim { get; set; }
    }

    public class Login :IdentityUserLogin<int>
    {
        [Key]
        public int idLogin { get; set; }

    }

    public class UserRole : IdentityUserRole<int>

    {
        [Key]
        public int idRole { get; set; }

    }

    public class Role : IdentityRole<int,UserRole>
    {
        public Role()
        {
                
        }
        public Role(String name)
        {
            Name = name;
        }
    }
}
