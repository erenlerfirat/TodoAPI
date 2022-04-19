﻿using System;
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
        public int TodoDetailId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string TodoName { get; set; }
        public string CategoryName { get; set; }        
        public DateTime CreateDate { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public Category Category { get; set; } = new();
        public virtual ICollection<TodoDetail> TodoDetails { get; set; }
    }
}
