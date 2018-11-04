using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ClientModel
    {

        public String Type { get; set; }
        public int Duration { get; set; }
        public String Description { get; set; }
        public String Requirements { get; set; }
        public String ProfileNeeded { get; set; }
        public int YearsOfExperience { get; set; }
        public String Experience { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

    }
}