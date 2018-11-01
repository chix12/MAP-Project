﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RecruitementManager : User
    {
        [Key]
        public int IdManager { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
