using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public class Mandat
    {
        [Key]
        public int MandatId { get; set; }
        public Ressource Ressource { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        /* [ForeignKey("IdProject")]
         public virtual Project Project { get; set; }
         public int? IdProject { get; set; }*/

    }
}
