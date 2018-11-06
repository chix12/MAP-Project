using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
   public class OrganizationalChart
    {
        [Key]
        public int IdChart { get; set; }
        [ForeignKey("IdRessource")]
        public virtual Ressource Ressource { get; set; }
        public int? IdRessource { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        public int? IdClient { get; set; }
        [ForeignKey("IdProject")]
        public virtual Project Project { get; set; }
        public int? IdProject { get; set; }

    }
}
