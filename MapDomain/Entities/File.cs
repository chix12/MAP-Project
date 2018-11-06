using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
   public class File
    {
        [Key]
        public int IdFile { get; set; }
        [ForeignKey("IdRessource")]
        public JobSeeker JobSeeker { get; set; }
        public virtual int? IdRessource { get; set; }
    }

}
