using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Models
{
    public class MandatModel
    {
        
        
        [Display(Name = "Ajout Mandat")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MandatId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int? IdRessource { get; set; }

        public IEnumerable<SelectListItem> Ressources { get; set; }


    }
}
