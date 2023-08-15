using Core.Entity;
using System;

namespace Entity.Domain
{
    public class TodoDetail : IEntity
    {   
        public int Id { get; set; }
        public string ContentDetail { get; set; }               
        public DateTime CreateDate { get; set; }        
        
    }
}
