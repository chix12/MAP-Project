using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
   public class Competence
    {
        [Key]
        public int IdCompetence { get; set; }
        public String CompetenceName { get; set; }
        public int Rank { get; set; }
        public virtual ICollection<RessourceForm> RessourceForms { get; set; }
    }
}

