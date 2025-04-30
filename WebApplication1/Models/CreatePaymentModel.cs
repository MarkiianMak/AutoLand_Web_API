

namespace AutoLand_API
{
    public class CreatePaymentModel
    {
        public int UserId { get; set; }


        public double? Amount { get; set; }

        public string? Type { get; set; }

        public DateTime Date { get; set; }

    }
}
