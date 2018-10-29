using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Ressource
    {
        public int idRessource { get; set; }
        //public ContractType type { get; set; }
        public int rating { get; set; }
        public String seniority { get; set; }
        public String status { get; set; }
        public String Name { get; set; }
        public Profile profile { get; set; }
        public ICollection<Vaccations> vaccations { get; set; }
        public ICollection<Competence> competences { get; set; }

    }
}
