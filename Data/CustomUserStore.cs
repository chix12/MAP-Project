using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data
{
    class CustomUserStore : UserStore<User, Role, int, Login, UserRole, Claim>
    {
        public CustomUserStore(MyContext context) : base(context)
        {

        }
    }
}
