using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client
    {
        public int IdClient { get; set; }
        public String Type { get; set; }
        public String Category { get; set; }
        public String Name { get; set; }
        public String Photo { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<ClientRequestForm> ClientRequestForm { get; set; }
        public virtual OrganizationalChart OrganizationalChart { get; set; }
    }
}
