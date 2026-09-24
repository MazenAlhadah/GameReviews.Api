using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Game : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Developer { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Decimal AverageRating { get; set; }
        public int ReviewsCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Review> Reviews { get; set; }


    }
}
