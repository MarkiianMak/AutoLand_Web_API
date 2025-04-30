using AutoLand_API;

namespace WebApplication1
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int? Year { get; set; }
        public string BodyType { get; set; } = string.Empty;
        public int? Mileage { get; set; }
        public string FuelType { get; set; } = string.Empty;
        public string NumberPlate { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Status { get; set; } = string.Empty;

        public List<ReviewDto> Reviews { get; set; } = new();
        public List<CRentDto>? Rents { get; set; } = new ();
    }

}
