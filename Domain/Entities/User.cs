using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public List<Review> Reviews { get; set; }
    }
}
