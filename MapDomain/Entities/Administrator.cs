using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public class Administrator : User
    {
        //[Key]
        //public int IdAdministrator { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
