using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLand_API
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public decimal? Amount { get; set; }

        public string? Type { get; set; }

        public DateTime Date { get; set; }

    }
}
