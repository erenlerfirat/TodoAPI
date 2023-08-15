using Core.Entity;
using System;

namespace Entity.Domain
{
    public class Todo : IEntity
    {   
        public int Id { get; set; }
        public int TodoDetailId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string TodoName { get; set; }
        public string ImportanceLevel { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeadlineDate { get; set; }
    }
}
