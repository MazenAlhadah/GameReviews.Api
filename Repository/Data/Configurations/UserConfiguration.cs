using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.Email).HasMaxLength(256).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.DisplayName).HasMaxLength(100);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()").IsRequired();
            builder.HasMany(x=>x.Reviews).WithOne(x=>x.User).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
