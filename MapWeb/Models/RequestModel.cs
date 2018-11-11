using MapDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Models
{
    public class RequestModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdForm { get; set; }
        public String Type { get; set; }
        [DataType(DataType.Currency)]
        public int Fees { get; set; }
        public String Description { get; set; }
        public String Requirements { get; set; }
        public String ProfileNeeded { get; set; }
        [Display(Name = "Years of Experience")]
        public int YearsOfExperience { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Project")]
        public int? IdProject { get; set; }
        //public IEnumerable<SelectListItem> Projects { get; set; }*/
    }
}