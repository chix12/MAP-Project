using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public class ClientRequestForm
    {
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
           [Key]
            public int IdForm { get; set; }
            public String Type { get; set; }
            public int Duration { get; set; }
            public String Description { get; set; }
            public String Requirements { get; set; }
            public String ProfileNeeded { get; set; }
            public int YearsOfExperience { get; set; }
            public String Experience { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            [ForeignKey("IdProject")]
            public Ressource Project { get; set; }
            public int? IdProject { get; set; }

        }
    }
