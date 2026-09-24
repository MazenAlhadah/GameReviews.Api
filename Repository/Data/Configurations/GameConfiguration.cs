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
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(x => x.Title);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.Developer).HasMaxLength(150);
            builder.Property(x => x.CoverImageUrl).HasMaxLength(500);
            builder.Property(x=>x.AverageRating).HasDefaultValue(0).IsRequired().HasPrecision(4,2);
            builder.Property(x => x.ReviewsCount).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.ReleaseDate).HasColumnType("date");
            builder.HasOne(x => x.Category).WithMany(x => x.Games).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Reviews).WithOne(x => x.Game).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(x => new { x.CategoryId , x.AverageRating}).IsDescending(false , true);
            builder.HasIndex(x => new { x.AverageRating, x.ReviewsCount }).IsDescending(true,true);
        }
    }
}
