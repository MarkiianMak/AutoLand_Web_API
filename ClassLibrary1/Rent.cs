using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLand_API
{
    public class Rent
    {
        public int Id { get; set; }

        public int? CarId { get; set; }
        public Car? Car { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public decimal? Price { get; set; }

        public string? Status { get; set; }
    }

}
