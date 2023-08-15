using Core.Entity;
using System;

namespace Entity.Domain
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDetail { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
