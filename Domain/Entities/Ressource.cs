using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Ressource
    {
        public int IdRessource { get; set; }
        //public ContractType type { get; set; }
        public int Rating { get; set; }
        public String Seniority { get; set; }
        public String Status { get; set; }
        public String Name { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Vaccations> Vaccations { get; set; }
        public virtual ICollection<Competence> Competences { get; set; }
        public virtual RessourceForm RessourceForm { get; set; }

    }
}
