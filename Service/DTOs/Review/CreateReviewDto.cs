using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Review
{
    public class CreateReviewDto
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

    }
}
