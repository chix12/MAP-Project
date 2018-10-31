using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message
    {
        [Key]
        public int IdMessage { get; set; }
        public String Sender { get; set; }
        public String Reciever { get; set; }
        public String Type { get; set; }
        public String Content { get; set; }

    }
}
