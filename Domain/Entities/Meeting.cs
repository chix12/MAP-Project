using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Meeting
    {
        [Key]

        public int IdMeeting { get; set; }
        public DateTime MeetingDate { get; set; }
        [ForeignKey("IdRessource")]
        public virtual Ressource Ressource { get; set; }
        public int? IdRessource { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        public int? IdClient { get; set; }
        [ForeignKey("IdManager")]
        public virtual RecruitementManager RecruitementManager { get; set; }
        public int? IdManager { get; set; }
    }
}
