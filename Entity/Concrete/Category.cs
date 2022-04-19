using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDetail { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Todo> Todos {get;set;}
    }
}
