using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Task
    {   [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string CategoryName { get; set; }
        public string TaskDetails { get; set; }
        public DateTime? TaskDate { get; set; }
    }
}
