using Core.Entity;
using System;
using System.Collections.Generic;

namespace Entity.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDetail { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
