using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class TodoDetail
    {
        public int Id { get; set; }
        public string ContentDetail { get; set; }               
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        
    }
}
