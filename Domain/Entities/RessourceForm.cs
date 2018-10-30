using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RessourceForm
    {
        public int IdForm { get; set; }
        public String RessourceFirstName { get; set; }
        public String RessourceLastName { get; set; }
        public virtual ICollection<Competence> Competences { get; set; }
        public virtual Ressource Ressource { get; set; }
    }
}
