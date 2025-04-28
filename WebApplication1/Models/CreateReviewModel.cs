

namespace AutoLand_API
{
    public class CreateReviewModel
    {
        public int SenderId { get; set; }

        public int? RecieverId { get; set; }
 
        public int? CarId { get; set; }

        public double Raiting { get; set; }

        public string? Comment { get; set; }
    }
}
