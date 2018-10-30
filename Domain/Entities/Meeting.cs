using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Meeting
    {
        public DateTime MeetingDate { get; set; }
        public virtual Ressource Ressource { get; set; }
        public virtual Client Client { get; set; }
        public virtual RecruitementManager RecruitementManager { get; set; }
    }
}
