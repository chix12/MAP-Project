using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class File
    {
        public int IdFile { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
    }
}
