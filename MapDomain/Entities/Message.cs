using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public class Message
    {
        
        [Key]
        public int IdMessage { get; set; }
        public String Sender { get; set; }
        public String Reciever { get; set; }
        public String Type { get; set; }
        public String Content { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        public int? IdClient { get; set; }
        [ForeignKey("IdRessource")]
        public Ressource Ressource { get; set; }
        public int? IdRessource { get; set; }

    }
}
