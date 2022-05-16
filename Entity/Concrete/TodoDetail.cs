using Core.IEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class TodoDetail : IEntity
    {   
        public int Id { get; set; }
        public string ContentDetail { get; set; }               
        public DateTime CreateDate { get; set; }        
        
    }
}
