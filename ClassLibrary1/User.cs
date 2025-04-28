using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLand_API
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string? Type { get; set; }

        public double? Raiting { get; set; }

        public string? Licence { get; set; }


        public ICollection<Car>? OwnedCars { get; set; } = new List<Car>();


        public ICollection<Rent>? Rents { get; set; }    = new List<Rent>();

        public ICollection<Review>? RewiewsReceived { get; set; } = new List<Review>();



    }
}
