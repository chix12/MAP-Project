using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public enum ProjectType { newProject, ProjectInProgress, CompletedProject }
    public class Project
    {
        [Key]
        public int IdProject { get; set; }
        public String Name { get; set; }
        public String Logo { get; set; }
        public String Address { get; set; }
        public virtual ICollection<Ressource> Ressources { get; set; }
        [ForeignKey("IdMandat")]
        public virtual Mandat Mandat { get; set; }
        public int? IdMandat { get; set; }
        /*[ForeignKey("IdForm")]
        public virtual ClientRequestForm ClientRequestForm { get; set; }
        public int? IdForm { get; set; }*/
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        public int? IdClient { get; set; }
        /*[ForeignKey("IdChart")]
        public virtual OrganizationalChart OrganizationalChart { get; set; }
        public int IdChart { get; set; }*/
    }
   
}
