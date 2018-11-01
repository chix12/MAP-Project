using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : IdentityUser<String, Login, Role, Claim>
    {
        [Key]
        public int UserId { get; set;
        }
    }
    public class Claim : IdentityUserClaim
    {
        [Key]
        public int idClaim { get; set; }
    }

    public class Login :IdentityUserLogin
    {
        [Key]
        public int idLogin { get; set; }

    }

    public class Role : IdentityUserRole

    {
        [Key]
        public int idRole { get; set; }

    }
}
