using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapDomain.Entities
{
    public class Candidacy
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRequest { get; set; }
        [Key, Column(Order = 1)]
        public int? UserId { get; set; }
        public StateType Status { get; set; }
        public DateTime RequestDate { get; set; }
        public virtual Demandeur d { get; set; }
        public virtual ICollection<JobSeeker> JobSeekers { get; set; }
    }
}
