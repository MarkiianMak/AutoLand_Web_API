using AutoLand_API;

namespace WebApplication1
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string? Type { get; set; }

        public double? Raiting { get; set; }

        public string? Licence { get; set; }


        public ICollection<CarDto>? OwnedCars { get; set; } = new List<CarDto>();
        public ICollection<URentDto>? Rents { get; set; } = new List<URentDto>();
        public ICollection<ReviewDto>? Reviews { get; set; } = new List<ReviewDto>();
        public ICollection<Payment>? Payments { get; set; } = new List<Payment>();
    }
}
