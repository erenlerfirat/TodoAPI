using Core.Constants;
using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DataAccess.Concrete.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.MiddleName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(200);
            builder.Property(t => t.CreateDate).HasColumnType(EntityColumnTypes.Date);

            builder.HasData(new List<User> {
                new User { Id = 1, FirstName="Firat",LastName="Erenler", Email="erenler.firat@gmail.com",MiddleName = "", 
                    UserName="firat123", CreateDate = System.DateTime.MinValue ,
                    PasswordHash = "0067D8AA8A79D218195BE099403E38B069A1B5CF5B2E30A2D294813E67D0C776:A2AE4319FBB2FD038B3C7E1F096A8FF4"}, 
            });
        }
    }
}
