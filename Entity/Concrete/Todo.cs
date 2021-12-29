using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Todo
    {   [Key]
        public int TodoId { get; set; }
        public string TodoName { get; set; }
        public string CategoryName { get; set; }
        public string TodoDetails { get; set; }
        public DateTime? TodoDate { get; set; }
    }
}
