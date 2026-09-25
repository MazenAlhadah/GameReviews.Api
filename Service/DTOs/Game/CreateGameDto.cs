using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Game
{
    public class CreateGameDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Developer { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
