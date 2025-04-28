using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLand_API
{
    public class Review
    {

        public int Id { get; set; }
        public int SenderId { get; set; }
        public User? Sender { get; set; }

        public int? RecieverId { get; set; }
        public User? Reciever { get; set; }
        public int? CarId { get; set; }

        public Car? Car { get; set; }


        public double? Raiting { get; set; }

        public string? Comment { get; set; }

    }
}
