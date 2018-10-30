using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class JobSeeker : Ressource
    {
        public String Specialty { get; set; }
        public virtual JobRequest JobRequest { get; set; }
        public virtual File File { get; set; }
    }
}
