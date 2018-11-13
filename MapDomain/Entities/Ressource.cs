using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapDomain.Entities
{

    public enum ContractType { Employee, Freelancer }
    public enum AvailibilityType { Available, Unavailable, AvailableSoon }
    public class Ressource : User
    {

        //[Key]
        //public int IdRessource { get; set; }
        public ContractType typec { get; set; }
        public int Rating { get; set; }
        public String Seniority { get; set; }
        public String Status { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Vaccations> Vaccations { get; set; }
        public virtual ICollection<Competence> Competences { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        [ForeignKey("IdProfile")]
        public virtual Profile Profile { get; set; }
        public int? IdProfile { get; set; }
        /* [ForeignKey("IdChart")]
         public virtual OrganizationalChart OrganizationalChart { get; set; }
         public int? IdChart { get; set; }*/
        /*[ForeignKey("IdForm")]
        public virtual RessourceForm RessourceForm { get; set; }
        public int? IdForm { get; set; }*/

    
}
}
