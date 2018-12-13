using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public enum CountryList {  Afghanistan,Albania,Algeria,India,Indonesia,Iran,Tunisia,Turkey  }
    public class Demandeur : User
    {
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String PassPort { get; set; }
        public String Picture { get; set; }
        public CountryList Country { get; set; }

        public WorkType WorkType { get; set; }
        public StateType Status { get; set; }
        public DateTime RequestDate { get; set; }
        public virtual ICollection<JobRequest> JobRequests { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
