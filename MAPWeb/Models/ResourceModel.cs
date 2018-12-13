using MapDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Models
{
    public class ResourceModel
    {

        public int Rating { get; set; }
        public String Seniority { get; set; }
        public String Status { get; set; }
        
        public String Name { get; set; }

        public String ProfileT { get; set; }

        public String Email { get; set; }
        public String UserName { get; set; }

        public virtual ICollection<Vaccations> Vaccations { get; set; }
        public virtual ICollection<Competence> Competences { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
      
        public int? IdProfile { get; set; }

        public IEnumerable<SelectListItem> Profiles { get; set; }

        public String CurriculumVitae { get; set; }


        [Display(Name = "Project")]
        public int? IdProject { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }

    }
}