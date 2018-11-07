using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public class Meeting
    {
        [Key]
        public int IdMeeting { get; set; }
        public DateTime MeetingDate { get; set; }
     
        public virtual Ressource Ressource { get; set; }
        [ForeignKey("Ressource")]
        public int? IdRessource { get; set; }
 
        public virtual Client Client { get; set; }
        [ForeignKey("Client")]
        public int? IdClient { get; set; }
       
        public virtual Administrator Administrator { get; set; }
        [ForeignKey("Administrator")]
        public int? IdAdministrator { get; set; }
    }

}
