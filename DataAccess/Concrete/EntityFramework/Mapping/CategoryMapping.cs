using Core.Constants;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CategoryDetail);
            builder.Property(c => c.CreateDate).HasColumnType(EntityColumnTypes.Date);
            builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(50);

            builder.HasMany(c => c.Todos).WithOne();
        }
    }
}
