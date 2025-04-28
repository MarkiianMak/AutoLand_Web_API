using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLand_API

{
    public class Car
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }

        public int? Year { get; set; }


        public string? BodyType { get; set; }

        public decimal? Mileage { get; set; }

        public string? FuelType { get; set; }

        public string? NumberPlate { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public int? Price { get; set; }
        public string? Status { get; set; }

        public ICollection<Review>? Reviews { get; set; }  = new List<Review>();



    }
}
