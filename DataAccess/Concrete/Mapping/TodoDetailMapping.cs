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
    public class TodoDetailMapping : IEntityTypeConfiguration<TodoDetail>
    {
        public void Configure(EntityTypeBuilder<TodoDetail> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.ContentDetail).IsRequired();
            builder.Property(t => t.CreateDate).HasColumnType(EntityColumnTypes.Date);

        }
    }
}
