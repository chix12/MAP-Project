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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdForm { get; set; }
        public String Type { get; set; }
        //public int Duration { get; set; }
        [DataType(DataType.Currency)]
        public int Fees { get; set; }
        public String Description { get; set; }
        public String Requirements { get; set; }
        public String ProfileNeeded { get; set; }
        public int YearsOfExperience { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [ForeignKey("IdProject")]
        public Project Project { get; set; }
        public int? IdProject { get; set; }
    }
    }
