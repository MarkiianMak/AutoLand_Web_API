using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLand_API
{
    public class Insurance
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public Car? Car { get; set; }
        public string? Type { get; set; }

        public int? Period { get; set; }

        public string? CompanyName { get; set; }
    }
}
