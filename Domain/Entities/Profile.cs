using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Profile
    {
        [Key]
        public int IdProfile { get; set; }
        public String ProfileName { get; set; }
        public virtual ICollection<Ressource> Ressources { get; set; }
    }
}
