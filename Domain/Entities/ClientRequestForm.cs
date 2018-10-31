using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClientRequestForm
    {
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
        public Project Project { get; set; }
        public int? IdProject { get; set; }

    }
}
