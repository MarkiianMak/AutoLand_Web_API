using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutoLand_API
{
    public class Review
    {

        public int Id { get; set; }
        public int? RecieverId { get; set; }
        [JsonIgnore]
        public User? Reciever { get; set; } = null!;
        public int? CarId { get; set; }
        [JsonIgnore]
        public Car? Car { get; set; } = null!;


        public double? Raiting { get; set; }

        public string? Comment { get; set; }

    }
}
