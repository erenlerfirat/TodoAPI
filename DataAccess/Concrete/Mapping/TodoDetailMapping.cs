﻿using Core.Constants;
using Entity.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Mapping
{
    public class TodoDetailMapping : IEntityTypeConfiguration<TodoDetail>
    {
        public void Configure(EntityTypeBuilder<TodoDetail> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.ContentDetail).IsRequired();
            builder.Property(t => t.CreateDate).HasColumnType(EntityColumnTypes.Date);

            builder.HasData(new List<TodoDetail> { 
                new TodoDetail { Id = 1, ContentDetail = "Reading the database engineering articles ", CreateDate = DateTime.MinValue } ,
                new TodoDetail { Id = 2, ContentDetail = "Reading the clean code book of robert c. martin ", CreateDate = DateTime.MinValue }
            });

        }
    }
}
