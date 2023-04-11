using Core.Constants;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace DataAccess.Concrete.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CategoryDetail);
            builder.Property(c => c.CreateDate).HasColumnType(EntityColumnTypes.Date);
            builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(50);

            builder.HasData(new List<Category> {
                new Category{Id = 1, CategoryName = "Readings",CreateDate = DateTime.MinValue, CategoryDetail = "Saved articles , documents to read"},
                new Category{Id = 2,CategoryName = "Books",CreateDate = DateTime.MinValue, CategoryDetail = "The books that I want to read this year"},
                new Category{Id = 3, CategoryName = "Payments",CreateDate = DateTime.MinValue, CategoryDetail = "The bills that I need to remember to pay"},
                new Category{Id = 4,CategoryName = "Training",CreateDate = DateTime.MinValue, CategoryDetail = "My weekly or monthly training program"},
            });
        }
    }
}
