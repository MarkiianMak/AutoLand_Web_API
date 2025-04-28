

namespace AutoLand_API
{
    public class CreatePaymentModel
    {
        public int UserId { get; set; }


        public decimal? Amount { get; set; }

        public string? Type { get; set; }

        public DateTime Date { get; set; }

    }
}
