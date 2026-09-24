using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Rating).IsRequired();
            builder.Property(s => s.Comment).HasMaxLength(1000);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()").IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Reviews).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Game).WithMany(x => x.Reviews).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(x => new { x.UserId, x.GameId }).IsUnique();
            builder.ToTable(t => { t.HasCheckConstraint("CheckRating", "Rating >= 1 AND Rating <=10"); });
        }
    }
}
