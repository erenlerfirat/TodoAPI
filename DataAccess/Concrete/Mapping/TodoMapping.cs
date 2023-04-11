using Core.Constants;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Mapping
{
    public class TodoMapping : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.DeadlineDate).HasColumnType(EntityColumnTypes.Date);
            builder.Property(t => t.CreateDate).HasColumnType(EntityColumnTypes.Date);
            builder.Property(t => t.TodoDetailId).IsRequired();
            builder.Property(t => t.CategoryId).IsRequired();
            builder.Property(t => t.UserId).IsRequired();
            builder.Property(t => t.TodoName).IsRequired().HasMaxLength(100);
            builder.Property(t => t.ImportanceLevel).HasMaxLength(15);

            builder.HasData(new List<Todo> {
                new Todo { Id = 1, CategoryId = 3 , CreateDate = DateTime.MinValue , TodoName = "Electricity bill"} ,
                new Todo { Id = 2, CategoryId =4 , CreateDate = DateTime.MinValue , TodoName = "Training planned "}
            });
        }
    }
}
