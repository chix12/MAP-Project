using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project
    {
        [Key]
        public int IdProject { get; set; }
        public String Name { get; set; }
        public String Logo { get; set; }
        public String Address  { get; set; }
        public virtual ICollection<Ressource> Ressources { get; set; }

    }
}
