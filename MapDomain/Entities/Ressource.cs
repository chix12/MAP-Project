using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapDomain.Entities
{

    public enum ContractType { Employee, Freelancer }
    public enum WorkType { IT, HR, Finance, Administration }
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
        public virtual ICollection<Mandat> Mandats { get; set; }
        public virtual ICollection<Competence> Competences { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
       
        public virtual Profile Profile { get; set; }
        public String ProfileT { get; set; }

        public String CurriculumVitae { get; set; }

        [ForeignKey("IdProject")]
        public Project Project { get; set; }
        [Display(Name = "Project")]
        public int? IdProject { get; set; }


    }
}
