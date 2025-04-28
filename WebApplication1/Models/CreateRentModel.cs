

namespace AutoLand_API { 
    public class CreateRentModel
    {

        public int? CarId { get; set; }

        public int? UserId { get; set; }
   
        public DateTime? Start { get; set; }
        public decimal? Price { get; set; }

    }
}
